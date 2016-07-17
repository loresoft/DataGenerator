using System;

namespace DataGenerator.Sources
{

    /// <summary>
    /// Static value data source
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <seealso cref="DataGenerator.IDataSource" />
    public class ValueSource<T> : IDataSource
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueSource{T}"/> class.
        /// </summary>
        /// <param name="value">The static value.</param>
        public ValueSource(T value)
        {
            Value = value;
        }


        /// <summary>
        /// Gets the static value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; }


        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public object NextValue(IGenerateContext generateContext)
        {
            return Value;
        }
    }
}