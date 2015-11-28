using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DataGenerator.Extensions;
using DataGenerator.Logging;

namespace DataGenerator
{
    /// <summary>
    /// A class defining the DataGenerator configuration.
    /// </summary>
    public class Configuration
    {
        private readonly ConcurrentDictionary<string, object> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            _cache = new ConcurrentDictionary<string, object>();
            Mapping = new ConcurrentDictionary<Type, ClassMapping>();
            Assemblies = new AssemblyResolver();
            AutoMap = true;


            // exclude system assemblies
            Assemblies.ExcludeName("mscorlib");
            Assemblies.ExcludeName("Microsoft");
            Assemblies.ExcludeName("System");
            

        }

        /// <summary>
        /// Gets the assemblies used by DataGenerator.
        /// </summary>
        /// <value>
        /// The assemblies use by DataGenerator.
        /// </value>
        public AssemblyResolver Assemblies { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to automatic map properties of the class by default.
        /// </summary>
        /// <value>
        ///   <c>true</c> to automatic map properties; otherwise, <c>false</c>.
        /// </value>
        public bool AutoMap { get; set; }

        /// <summary>
        /// Gets the mapped class definitions.
        /// </summary>
        /// <value>
        /// The mapped class definitions.
        /// </value>
        public ConcurrentDictionary<Type, ClassMapping> Mapping { get; }


        /// <summary>
        /// Gets a list of <see cref="IDataSourceDiscover"/> by scanning the <see cref="Assemblies"/>.
        /// </summary>
        /// <remarks>
        /// The result of the assembly scan is cached.  Repeated calls will return results from cache.  Call <see cref="ClearCache"/> to re-scan assemblies.
        /// </remarks>
        /// <returns>The discovered data sources</returns>
        public IEnumerable<IDataSourceDiscover> DataSources()
        {
            var dataSources = _cache.GetOrAdd("DataSource", k =>
            {
                var assemblies = Assemblies.Resolve().ToList();

                return assemblies
                    .SelectMany(GetTypesAssignableFrom<IDataSourceDiscover>)
                    .Select(CreateInstance)
                    .OfType<IDataSourceDiscover>()
                    .ToList();
            });

            return dataSources as IEnumerable<IDataSourceDiscover>;
        }

        /// <summary>
        /// Clears the cached data sources.
        /// </summary>
        public void ClearCache()
        {
            _cache.Clear();
        }


        private static IEnumerable<Type> GetTypesAssignableFrom<T>(Assembly assembly)
        {
            Logger.Trace()
                .Message("Scan Start; Assembly: '{0}', Type: '{1}'", assembly.FullName, typeof(T))
                .Write();

            Stopwatch watch = Stopwatch.StartNew();
            var types = assembly.GetTypesAssignableFrom<T>();
            watch.Stop();

            Logger.Trace()
                .Message("Scan Complete; Assembly: '{0}', Type: '{1}', Time: {2} ms", assembly.FullName, typeof(T), watch.ElapsedMilliseconds)
                .Write();

            return types;
        }

        private static object CreateInstance(Type type)
        {
            Logger.Trace()
                .Message("Create Instance: {0}", type)
                .Write();

            return Activator.CreateInstance(type);
        }

    }
}