using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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
        /// Include the <see cref="AppDomain"/> loaded assemblies as a source.
        /// </summary>
        public void IncludeLoadedAssemblies()
        {
            Sources.Add(() => AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// Include the assembly from the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to get assembly from.</typeparam>
        public void IncludeAssemblyFor<T>()
        {
            IncludeAssembly(typeof(T).Assembly);
        }

        /// <summary>
        /// Include the specified <see cref="Assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to include.</param>
        public void IncludeAssembly(Assembly assembly)
        {
            Sources.Add(() => new[] { assembly });
        }

        /// <summary>
        /// Include the assemblies that contain the specified name.
        /// </summary>
        /// <param name="name">The name to compare.</param>
        public void IncludeName(string name)
        {
            Includes.Add(a => a.FullName.Contains(name));
        }


        /// <summary>
        /// Exclude the assembly from the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to get assembly from.</typeparam>
        public void ExcludeAssemblyFor<T>()
        {
            ExcludeAssembly(typeof(T).Assembly);
        }

        /// <summary>
        /// Exclude the specified <see cref="Assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to exclude.</param>
        public void ExcludeAssembly(Assembly assembly)
        {
            Excludes.Add(a => a == assembly);
        }

        /// <summary>
        /// Exclude the assemblies that start with the specified name.
        /// </summary>
        /// <param name="name">The name to compare.</param>
        public void ExcludeName(string name)
        {
            Excludes.Add(a => a.FullName.Contains(name));
        }


        /// <summary>
        /// Resolves a list of assemblies using the <see cref="Sources"/>, <see cref="Includes"/>, and <see cref="Excludes"/> rules.
        /// </summary>
        /// <returns>An enumberable list of assemblies.</returns>
        public IEnumerable<Assembly> Resolve()
        {
            // default to loaded assemblies
            if (_sources.Count == 0)
                _sources.Add(() => AppDomain.CurrentDomain.GetAssemblies());

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