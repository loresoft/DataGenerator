using System;

namespace DataGenerator.Sources
{
    /// <summary>
    ///   <see cref="DateTime" /> data source generator
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourcePropertyType" />
    public class DateTimeSource : DataSourcePropertyType
    {
        private readonly DateTime _min;
        private readonly DateTime _max;


        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeSource"/> class.
        /// </summary>
        public DateTimeSource()
            : base(new[] { typeof(DateTime), typeof(DateTimeOffset) })
        {
            int year = DateTime.Now.Year;
            _min = new DateTime(year - 10, 1, 1);
            _max = new DateTime(year + 3, 1, 1);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeSource"/> class.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        public DateTimeSource(DateTime min, DateTime max)
            : base(new[] { typeof(DateTime), typeof(DateTimeOffset) })
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

            var nextValue = _min.AddTicks(ticks);

            if (generateContext?.MemberType == typeof(DateTimeOffset))
                return new DateTimeOffset(nextValue);

            return nextValue;
        }
    }
}
