using System;

namespace DataGenerator.Sources
{
    /// <summary>
    ///   <see cref="Decimal" /> data source generator
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourcePropertyType" />
    public class DecimalSource : DataSourcePropertyType
    {
        private readonly decimal _min;
        private readonly decimal _max;
        private readonly int? _decimals;


        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalSource"/> class.
        /// </summary>
        public DecimalSource()
            : this(0, 1000000, 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalSource"/> class.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        public DecimalSource(decimal min, decimal max)
            : this(min, max, 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalSource"/> class.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="decimals">The number of decimal places.</param>
        public DecimalSource(decimal min, decimal max, int decimals)
            : base(new[] { typeof(decimal) })
        {
            _min = min;
            _max = max;
            _decimals = decimals;
        }


        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public override object NextValue(IGenerateContext generateContext)
        {
            // Perform arithmetic in double type to avoid overflowing
            var range = (double)_max - (double)_min;
            var sample = RandomGenerator.Current.NextDouble();
            var scaled = (sample * range) + (double)_min;

            return _decimals.HasValue
                ? Math.Round((decimal)scaled, _decimals.Value)
                : (decimal)scaled;
        }
    }
}
