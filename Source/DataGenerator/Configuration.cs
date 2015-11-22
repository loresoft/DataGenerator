using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using DataGenerator.Extensions;
using DataGenerator.Logging;

namespace DataGenerator
{
    /// <summary>
    /// A class defining the DataGenerator configuration.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutoMap = true;

            Assemblies = new AssemblyResolver();

            // exclude system assemblies
            Assemblies.ExcludeName("mscorlib");
            Assemblies.ExcludeName("Microsoft");
            Assemblies.ExcludeName("System");
            

            Mapping = new ConcurrentDictionary<Type, ClassMapping>();
        }

        /// <summary>
        /// Gets the assemblies used by DataGenerator.
        /// </summary>
        /// <value>
        /// The assemblies use by DataGenerator.
        /// </value>
        public AssemblyResolver Assemblies { get; }

        public bool AutoMap { get; set; }

        public ConcurrentDictionary<Type, ClassMapping> Mapping { get; }


        public IEnumerable<IDataSourceDiscover> DataSources()
        {
            var assemblies = Assemblies.Resolve().ToList();

            return assemblies
                .SelectMany(GetTypesAssignableFrom<IDataSourceDiscover>)
                .Select(CreateInstance)
                .OfType<IDataSourceDiscover>();
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