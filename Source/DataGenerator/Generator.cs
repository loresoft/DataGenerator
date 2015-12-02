using System;
using System.Collections.Generic;
using System.Linq;
using DataGenerator.Fluent;
using DataGenerator.Reflection;

namespace DataGenerator
{

    /// <summary>
    /// Generate intelligent and realistic test data for an object.
    /// </summary>
    public class Generator
    {
        private static readonly Random _random;

        static Generator()
        {
            Configuration = new Configuration();
            _random = new Random();
        }

        /// <summary>
        /// Gets the generator configuration.
        /// </summary>
        /// <value>
        /// The generator configuration.
        /// </value>
        public static Configuration Configuration { get; }

        /// <summary>
        /// Configures the generator with specified fluent <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The fluent builder <see langword="delegate"/>.</param>
        public static void Configure(Action<ConfigurationBuilder> builder)
        {
            var configurationBuilder = new ConfigurationBuilder(Configuration);
            builder(configurationBuilder);
        }


        /// <summary>
        /// Generates a new instance of type <typeparamref name="T"/> with the properties set according to configuration.
        /// </summary>
        /// <typeparam name="T">The type to generate.</typeparam>
        /// <returns>A new instance of type <typeparamref name="T"/> with the properties set according to configuration.</returns>
        public static T Single<T>() where T : class
        {
            var type = typeof(T);
            var classMapping = GetMapping(type);

            var instance = GenerateInstance<T>(classMapping);

            return instance;
        }

        /// <summary>
        /// Generates a new instance of type <typeparamref name="T"/> with specified fluent configuration <paramref name="builder"/>.
        /// </summary>
        /// <typeparam name="T">The type to generate.</typeparam>
        /// <returns>A new instance of type <typeparamref name="T"/> with the properties set according to configuration.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> is <see langword="null" />.</exception>
        public static T Single<T>(Action<ClassMappingBuilder<T>> builder) where T : class
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var type = typeof(T);

            // copy class mapping before changes
            var classMapping = GetMapping(type).Clone();

            // allow overriding class mapping
            var mappingBuilder = new ClassMappingBuilder<T>(classMapping);
            builder(mappingBuilder);

            var instance = GenerateInstance<T>(classMapping);

            return instance;
        }


        /// <summary>
        /// Generates a random number of type <typeparamref name="T"/> with the properties set according to configuration.
        /// </summary>
        /// <typeparam name="T">The type to generate.</typeparam>
        /// <returns>A list of type <typeparamref name="T"/> with the properties set according to configuration.</returns>
        public static IList<T> List<T>() where T : class
        {
            return List<T>(2, 10);
        }

        /// <summary>
        /// Generates a random number between <paramref name="min"/> and <paramref name="max"/> of type <typeparamref name="T"/> with the properties set according to configuration.
        /// </summary>
        /// <typeparam name="T">The type to generate.</typeparam>
        /// <returns>A list of type <typeparamref name="T"/> with the properties set according to configuration.</returns>
        public static IList<T> List<T>(int min, int max) where T : class
        {
            var count = _random.Next(min, max);
            return List<T>(count);
        }

        /// <summary>
        /// Generates a <paramref name="count"/> of type <typeparamref name="T"/> with the properties set according to configuration.
        /// </summary>
        /// <typeparam name="T">The type to generate.</typeparam>
        /// <returns>A list of type <typeparamref name="T"/> with the properties set according to configuration.</returns>
        public static IList<T> List<T>(int count) where T : class
        {
            var type = typeof(T);
            var classMapping = GetMapping(type);

            // generate at least one 
            count = Math.Max(1, count);
            var list = new List<T>(count);

            for (int i = 0; i < count; i++)
            {
                var instance = GenerateInstance<T>(classMapping);
                list.Add(instance);
            }

            return list;
        }

        /// <summary>
        /// Generates a list of type <typeparamref name="T"/> with specified fluent configuration <paramref name="builder"/>.
        /// </summary>
        /// <typeparam name="T">The type to generate.</typeparam>
        /// <returns>A list of type <typeparamref name="T"/> with the properties set according to configuration.</returns>
        public static IList<T> List<T>(Action<ListGeneratorBuilder<T>> builder) where T : class
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var type = typeof(T);

            // copy class mapping before changes
            var classMapping = GetMapping(type).Clone();

            // allow overriding class mapping
            var mappingBuilder = new ListGeneratorBuilder<T>(classMapping);
            builder(mappingBuilder);

            // generate at least one 
            var count = Math.Max(1, mappingBuilder.GenerateCount);
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
