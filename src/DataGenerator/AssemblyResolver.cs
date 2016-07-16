using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DataGenerator.Reflection;

namespace DataGenerator
{
    /// <summary>
    /// A class to resolve assemblies for scanning.
    /// </summary>
    public class AssemblyResolver
    {
        private readonly List<Func<IEnumerable<Assembly>>> _sources;
        private readonly List<Func<Assembly, bool>> _includes;
        private readonly List<Func<Assembly, bool>> _excludes;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyResolver"/> class.
        /// </summary>
        public AssemblyResolver()
        {
            _sources = new List<Func<IEnumerable<Assembly>>>();
            _includes = new List<Func<Assembly, bool>>();
            _excludes = new List<Func<Assembly, bool>>();
        }

        /// <summary>
        /// Gets the assembly sources.
        /// </summary>
        /// <value>
        /// The assembly sources.
        /// </value>
        public List<Func<IEnumerable<Assembly>>> Sources
        {
            get { return _sources; }
        }

        /// <summary>
        /// Gets the include rules.
        /// </summary>
        /// <value>
        /// The include rules.
        /// </value>
        public List<Func<Assembly, bool>> Includes
        {
            get { return _includes; }
        }

        /// <summary>
        /// Gets the exclude rules.
        /// </summary>
        /// <value>
        /// The exclude rules.
        /// </value>
        public List<Func<Assembly, bool>> Excludes
        {
            get { return _excludes; }
        }


        /// <summary>
        /// Include the current loaded assemblies as a source.
        /// </summary>
        public void IncludeLoadedAssemblies()
        {
#if NETSTANDARD1_3 || NETSTANDARD1_6
            //TDOD figure out how to do this            
#else
            _sources.Add(() => AppDomain.CurrentDomain.GetAssemblies());
#endif
        }

        /// <summary>
        /// Include the assembly from the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to get assembly from.</typeparam>
        public void IncludeAssemblyFor<T>()
        {
            IncludeAssembly(typeof(T).GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Include the specified <see cref="Assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to include.</param>
        public void IncludeAssembly(Assembly assembly)
        {
            _sources.Add(() => new[] { assembly });
        }

        /// <summary>
        /// Include the assemblies that contain the specified name.
        /// </summary>
        /// <param name="name">The name to compare.</param>
        public void IncludeName(string name)
        {
            _includes.Add(a => a.FullName.Contains(name));
        }


        /// <summary>
        /// Exclude the assembly from the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to get assembly from.</typeparam>
        public void ExcludeAssemblyFor<T>()
        {
            ExcludeAssembly(typeof(T).GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Exclude the specified <see cref="Assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to exclude.</param>
        public void ExcludeAssembly(Assembly assembly)
        {
            _excludes.Add(a => a == assembly);
        }

        /// <summary>
        /// Exclude the assemblies that start with the specified name.
        /// </summary>
        /// <param name="name">The name to compare.</param>
        public void ExcludeName(string name)
        {
            _excludes.Add(a => a.FullName.Contains(name));
        }


        /// <summary>
        /// Resolves a list of assemblies using the <see cref="Sources"/>, <see cref="Includes"/>, and <see cref="Excludes"/> rules.
        /// </summary>
        /// <returns>An enumberable list of assemblies.</returns>
        public IEnumerable<Assembly> Resolve()
        {
            // default to loaded assemblies
            if (_sources.Count == 0)
                IncludeLoadedAssemblies();

            var assemblies = _sources
                .SelectMany(source => source())
                .Where(assembly => _includes.Count == 0 || _includes.Any(include => include(assembly)))
                .Where(assembly => _excludes.Count == 0 || !_excludes.Any(exclude => exclude(assembly)))
                .Distinct()
                .ToList();

            return assemblies;
        }
    }
}