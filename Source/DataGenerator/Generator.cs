using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Fluent;
using DataGenerator.Reflection;

namespace DataGenerator
{
    public class Generator
    {
        private static readonly Random _random;

        static Generator()
        {
            Configuration = new Configuration();
            _random = new Random();
        }

        public static Configuration Configuration { get; }

        public static void Configure(Action<ConfigurationBuilder> builder)
        {
            var configurationBuilder = new ConfigurationBuilder(Configuration);
            builder(configurationBuilder);
        }
     

        public static T Single<T>() where T : class
        {
            var type = typeof(T);
            var classMapping = GetMapping(type);

            var instance = GenerateInstance<T>(classMapping);

            return instance;
        }


        public static IList<T> List<T>() where T : class
        {
            return List<T>(2, 10);
        }

        public static IList<T> List<T>(int min, int max) where T : class
        {
            var count = _random.Next(min, max);
            return List<T>(count);
        }

        public static IList<T> List<T>(int count) where T : class
        {
            var type = typeof(T);
            var classMapping = GetMapping(type);

            var list = new List<T>(count);

            for (int i = 0; i < count; i++)
            {
                var instance = GenerateInstance<T>(classMapping);
                list.Add(instance);
            }

            return list;
        }


        private static T GenerateInstance<T>(ClassMapping classMapping) where T : class
        {
            var instance = classMapping.TypeAccessor.Create();
            foreach (var memberMapping in classMapping.Members)
            {
                if (memberMapping.Ignored || memberMapping.DataSource == null)
                    continue;

                var context = new GenerateContext
                {
                    ClassType = classMapping.TypeAccessor.Type,
                    MemberType = memberMapping.MemberAccessor.MemberType,
                    MemberName = memberMapping.MemberAccessor.Name,
                    Instance = instance
                };

                var value = memberMapping.DataSource.NextValue(context);
                SetValueWithCoercion(memberMapping.MemberAccessor, instance, value);
            }

            return instance as T;
        }


        private static ClassMapping GetMapping(Type type)
        {
            var mapping = Configuration.Mapping
                .GetOrAdd(type, t => new ClassMapping(TypeAccessor.GetAccessor(type)));

            if (mapping.Mapped)
                return mapping;

            bool autoMap = mapping.AutoMap || Configuration.AutoMap;
            if (!autoMap)
                return mapping;

            // thread-safe initialization 
            lock (mapping.SyncRoot)
            {
                if (mapping.Mapped)
                    return mapping;

                var typeAccessor = mapping.TypeAccessor;

                // scan for data sources
                var dataSources = Configuration
                    .DataSources()
                    .OrderBy(p => p.Priority)
                    .ToList();

                var properties = typeAccessor.GetProperties()
                    .Where(p => p.HasGetter && p.HasSetter);

                foreach (var property in properties)
                {
                    // get or create member
                    var memberMapping = mapping.Members.FirstOrDefault(m => m.MemberAccessor.Name == property.Name);
                    if (memberMapping == null)
                    {
                        memberMapping = new MemberMapping { MemberAccessor = property };
                        mapping.Members.Add(memberMapping);
                    }


                    // skip already mapped fields
                    if (memberMapping.Ignored || memberMapping.DataSource != null)
                        continue;


                    // search all for first match
                    var context = new MappingContext(mapping, memberMapping);
                    memberMapping.DataSource = dataSources.FirstOrDefault(d => d.TryMap(context));
                }

                mapping.Mapped = true;

                return mapping;
            }
        }


        private static void SetValueWithCoercion(IMemberAccessor targetAccessor, object target, object value)
        {
            Type memberType = targetAccessor.MemberType;
            Type valueType = value?.GetType().GetUnderlyingType();

            object v = ReflectionHelper.CoerceValue(memberType, valueType, value);
            targetAccessor.SetValue(target, v);
        }

    }

}
