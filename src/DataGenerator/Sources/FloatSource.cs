using System;

namespace DataGenerator.Sources
{
    /// <summary>
    ///   <see cref="Single" /> data source value generator
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourcePropertyType" />
    public class FloatSource : DataSourcePropertyType
    {
        private readonly float _min;
        private readonly float _max;
        private readonly int? _decimals;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatSource"/> class.
        /// </summary>
        public FloatSource()
            : this(0, 1000000, 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatSource"/> class.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        public FloatSource(float min, float max)
            : this(min, max, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatSource"/> class.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="decimals">The number of decimal places.</param>
        public FloatSource(float min, float max, int decimals)
            : base(new[] { typeof(float), typeof(double) })
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
            var range = (double)_max - _min;
            var sample = RandomGenerator.Current.NextDouble();
            var scaled = (sample * range) + _min;

            return _decimals == null
                ? (float)scaled
                : Math.Round(scaled, _decimals.Value);
        }
    }
}
