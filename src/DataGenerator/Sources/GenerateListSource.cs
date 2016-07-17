using System;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Generate a list of values data source
    /// </summary>
    /// <typeparam name="T">Type of values</typeparam>
    /// <seealso cref="DataGenerator.IDataSource" />
    public class GenerateListSource<T> : IDataSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateListSource{T}"/> class.
        /// </summary>
        /// <param name="count">The number of values to generate.</param>
        public GenerateListSource(int count)
        {
            Count = count;
        }

        /// <summary>
        /// Gets the number of values to generate.
        /// </summary>
        /// <value>
        /// The number of values to generate.
        /// </value>
        public int Count { get; }

        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public object NextValue(IGenerateContext generateContext)
        {
            return generateContext.Generator.List<T>(Count);
        }
    }
}