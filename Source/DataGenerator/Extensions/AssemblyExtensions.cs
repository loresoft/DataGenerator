using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DataGenerator.Extensions
{
    /// <summary>
    /// <see cref="Assembly"/> extension methods
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets the types assignable from <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to determine whether if it can be assigned.</typeparam>
        /// <param name="assembly">The assembly to search types.</param>
        /// <returns>An enumerable list of types the are assignable from <typeparamref name="T"/>.</returns>
        /// <exception cref="System.ArgumentNullException">When assembly is null.</exception>
        public static IEnumerable<Type> GetTypesAssignableFrom<T>(this Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            var type = typeof(T);

            return assembly
                .GetLoadableTypes()
                .Where(t => t.IsPublic && !t.IsAbstract && type.IsAssignableFrom(t));
        }

        /// <summary>
        /// Gets the public types defined in this assembly that are visible and can be loaded outside the assembly.
        /// </summary>
        /// <param name="assembly">The assembly to search types.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">assembly</exception>
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            Type[] types;

            try
            {
                types = assembly.GetExportedTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                //not interested in the types which cause the problem, load what we can
                types = e.Types.Where(t => t != null).ToArray();
            }

            return types;
        }
    }
}