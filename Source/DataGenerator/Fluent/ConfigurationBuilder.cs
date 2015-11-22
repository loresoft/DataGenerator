using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Reflection;

namespace DataGenerator.Fluent
{
    public class ConfigurationBuilder
    {
        public ConfigurationBuilder(Configuration configuration)
        {
            Configuration = configuration;
        }


        /// <summary>
        /// Gets the current configuration.
        /// </summary>
        /// <value>
        /// The current configuration.
        /// </value>
        public Configuration Configuration { get; }


        /// <summary>
        /// Include the <see cref="AppDomain" /> loaded assemblies as a source.
        /// </summary>
        /// <returns>
        /// A fluent <see langword="interface"/> to configure DataGenerator.
        /// </returns>
        public ConfigurationBuilder IncludeLoadedAssemblies()
        {
            Configuration.Assemblies.IncludeLoadedAssemblies();
            return this;
        }

        /// <summary>
        /// Include the assembly from the specified type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type to get assembly from.</typeparam>
        /// <returns>
        /// A fluent <see langword="interface"/> to configure DataGenerator.
        /// </returns>
        public ConfigurationBuilder IncludeAssemblyFor<T>()
        {
            return IncludeAssembly(typeof(T).Assembly);
        }

        /// <summary>
        /// Include the specified <see cref="Assembly" />.
        /// </summary>
        /// <param name="assembly">The assembly to include.</param>
        /// <returns>
        /// A fluent <see langword="interface"/> to configure DataGenerator.
        /// </returns>
        public ConfigurationBuilder IncludeAssembly(Assembly assembly)
        {
            Configuration.Assemblies.IncludeAssembly(assembly);
            return this;
        }

        /// <summary>
        /// Include the assemblies that contain the specified name.
        /// </summary>
        /// <param name="name">The name to compare.</param>
        /// <returns>
        /// A fluent <see langword="interface"/> to configure DataGenerator.
        /// </returns>
        public ConfigurationBuilder IncludeName(string name)
        {
            Configuration.Assemblies.IncludeName(name);
            return this;
        }


        /// <summary>
        /// Exclude the assembly from the specified type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type to get assembly from.</typeparam>
        /// <returns>
        /// A fluent <see langword="interface"/> to configure DataGenerator.
        /// </returns>
        public ConfigurationBuilder ExcludeAssemblyFor<T>()
        {
            return ExcludeAssembly(typeof(T).Assembly);
        }

        /// <summary>
        /// Exclude the specified <see cref="Assembly" />.
        /// </summary>
        /// <param name="assembly">The assembly to exclude.</param>
        /// <returns>
        /// A fluent <see langword="interface"/> to configure DataGenerator.
        /// </returns>
        public ConfigurationBuilder ExcludeAssembly(Assembly assembly)
        {
            Configuration.Assemblies.ExcludeAssembly(assembly);
            return this;
        }

        /// <summary>
        /// Exclude the assemblies that start with the specified name.
        /// </summary>
        /// <param name="name">The name to compare.</param>
        /// <returns>
        /// A fluent <see langword="interface"/> to configure DataGenerator.
        /// </returns>
        public ConfigurationBuilder ExcludeName(string name)
        {
            Configuration.Assemblies.ExcludeName(name);
            return this;
        }



        public ConfigurationBuilder Entity<TEntity>(Action<ClassMappingBuilder<TEntity>> builder)
        {
            var type = typeof(TEntity);
            var classMapping = Configuration.Mapping.GetOrAdd(type, t =>
            {
                var typeAccessor = TypeAccessor.GetAccessor(t);
                var mapping = new ClassMapping { TypeAccessor = typeAccessor };
                return mapping;
            });

            var mappingBuilder = new ClassMappingBuilder<TEntity>(classMapping);
            builder(mappingBuilder);

            return this;
        }
    }
}
