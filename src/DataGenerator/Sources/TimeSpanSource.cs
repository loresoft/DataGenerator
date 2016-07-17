using System;

namespace DataGenerator.Sources
{

    /// <summary>
    /// <see cref="TimeSpan"/> data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourcePropertyType" />
    public class TimeSpanSource : DataSourcePropertyType
    {
        private readonly TimeSpan _min;
        private readonly TimeSpan _max;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpanSource"/> class.
        /// </summary>
        public TimeSpanSource()
            : this(TimeSpan.Zero, TimeSpan.FromDays(1))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpanSource"/> class.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        public TimeSpanSource(TimeSpan min, TimeSpan max)
            : base(new[] { typeof(TimeSpan) })
        {
            _min = min;
            _max = max;
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
            var range = (_max - _min).Ticks;
            var ticks = (long)(RandomGenerator.Current.NextDouble() * range);
            return _min.Add(TimeSpan.FromTicks(ticks));
        }
    }
}
