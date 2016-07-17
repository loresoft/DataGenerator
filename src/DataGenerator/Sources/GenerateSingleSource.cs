using System;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Generate single value data source
    /// </summary>
    /// <typeparam name="T">Type to generate</typeparam>
    /// <seealso cref="DataGenerator.IDataSource" />
    public class GenerateSingleSource<T> : IDataSource
    {
        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public object NextValue(IGenerateContext generateContext)
        {
            return generateContext.Generator.Single<T>();
        }
    }
}