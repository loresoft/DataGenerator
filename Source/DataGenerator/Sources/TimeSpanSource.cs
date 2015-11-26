using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    public class TimeSpanSource : DataSourcePropertyType
    {
        private readonly TimeSpan _min;
        private readonly TimeSpan _max;
        private static readonly Random _random = new Random();

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
            var ticks = (long)(_random.NextDouble() * range);
            return _min.Add(TimeSpan.FromTicks(ticks));
        }
    }

    public static class TimeSpanSourceExtensions
    {
        public static MemberConfigurationBuilder<TEntity, TimeSpan> TimeSpanSource<TEntity>(this MemberConfigurationBuilder<TEntity, TimeSpan> builder, TimeSpan min, TimeSpan max)
        {
            builder.DataSource(() => new TimeSpanSource(min, max));
            return builder;
        }
    }

}
