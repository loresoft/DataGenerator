using System;

namespace DataGenerator
{
    /// <summary>
    /// A class for use in a random weighted value
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    public class WeightedValue<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeightedValue{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public WeightedValue(T value) : this(value, 1)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeightedValue{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="weight">The weight.</param>
        public WeightedValue(T value, int weight)
        {
            Weight = weight;
            Value = value;
        }

        /// <summary>
        /// Gets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public int Weight { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="WeightedValue{T}" /> to <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator T(WeightedValue<T> value)
        {
            return value == null ? default(T) : value.Value;
        }
    }
}