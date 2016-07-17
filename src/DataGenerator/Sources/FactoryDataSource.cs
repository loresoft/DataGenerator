using System;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Data source to generate a value with a factory method
    /// </summary>
    /// <typeparam name="T">Type returned from the factory method</typeparam>
    /// <seealso cref="DataGenerator.IDataSource" />
    public class FactoryDataSource<T> : IDataSource
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryDataSource{T}"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public FactoryDataSource(Func<T> factory)
        {
            Factory = factory;
        }

        /// <summary>
        /// Gets the factory method to generate a value with.
        /// </summary>
        /// <value>
        /// The factory method to generate a value with.
        /// </value>
        public Func<T> Factory { get; }

        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public object NextValue(IGenerateContext generateContext)
        {
            return Factory();
        }
    }
}