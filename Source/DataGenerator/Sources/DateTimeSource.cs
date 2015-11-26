using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    public class DateTimeSource : DataSourcePropertyType
    {
        private static readonly Random _random = new Random();

        private readonly DateTime _min;
        private readonly DateTime _max;


        public DateTimeSource()
            : base(new[] { typeof(DateTime), typeof(DateTimeOffset) })
        {
            int year = DateTime.Now.Year;
            _min = new DateTime(year - 10, 1, 1);
            _max = new DateTime(year + 3, 1, 1);
        }

        public DateTimeSource(DateTime min, DateTime max)
            : base(new[] { typeof(DateTime), typeof(DateTimeOffset) })
        {
            _min = min;
            _max = max;
        }


        public override object NextValue(IGenerateContext generateContext)
        {
            var range = (_max - _min).Ticks;
            var ticks = (long)(_random.NextDouble() * range);

            return _min.AddTicks(ticks);
        }
    }

    public static class DateTimeSourceExtensions
    {
        public static MemberConfigurationBuilder<TEntity, DateTime> DateTimeSource<TEntity>(this MemberConfigurationBuilder<TEntity, DateTime> builder, DateTime min, DateTime max)
        {
            builder.DataSource(() => new DateTimeSource(min, max));
            return builder;
        }

        public static MemberConfigurationBuilder<TEntity, DateTimeOffset> DateTimeSource<TEntity>(this MemberConfigurationBuilder<TEntity, DateTimeOffset> builder, DateTime min, DateTime max)
        {
            builder.DataSource(() => new DateTimeSource(min, max));
            return builder;
        }
    }

}
