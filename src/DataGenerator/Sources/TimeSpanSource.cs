using System;

namespace DataGenerator.Sources
{
    public class TimeSpanSource : DataSourcePropertyType
    {
        private readonly TimeSpan _min;
        private readonly TimeSpan _max;

        public TimeSpanSource()
            : this(TimeSpan.Zero, TimeSpan.FromDays(1))
        {
        }

        public TimeSpanSource(TimeSpan min, TimeSpan max)
            : base(new[] { typeof(TimeSpan) })
        {
            _min = min;
            _max = max;
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            var range = (_max - _min).Ticks;
            var ticks = (long)(RandomGenerator.Current.NextDouble() * range);
            return _min.Add(TimeSpan.FromTicks(ticks));
        }
    }
}
