using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DataGenerator.Reflection;

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
                throw new ArgumentNullException(nameof(assembly));

            var type = typeof(T);
            var typeInfo = type.GetTypeInfo();

            return assembly
                .GetLoadableTypes()
                .Where(t =>
                {
                    var i = t.GetTypeInfo();
                    return i.IsPublic && !i.IsAbstract && typeInfo.IsAssignableFrom(i);
                });
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
                throw new ArgumentNullException(nameof(assembly));

            // skip dynamic assemblies
            if (assembly.IsDynamic)
                return Enumerable.Empty<Type>();

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
            catch (NotSupportedException)
            {
                // some assemblies don't support getting types, ignore
                return Enumerable.Empty<Type>();
            }

            return types;
        }

#if NET40 || PORTABLE
        /// <summary>
        /// Retrieves an object that represents this type.
        /// </summary>
        /// <param name="type">Type to retrieve</param>
        /// <returns></returns>
        public static Type GetTypeInfo(this Type type)
        {
            return type;
        }
#endif
    }
}