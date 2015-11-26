using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    public class DecimalSource : DataSourcePropertyType
    {
        private static readonly Random _random = new Random();

        private readonly decimal _min;
        private readonly decimal _max;
        private readonly int? _decimals;


        public DecimalSource()
            : this(0, 1000000, 2)
        {
        }

        public DecimalSource(decimal min, decimal max)
            : this(min, max, 0)
        {
        }

        public DecimalSource(decimal min, decimal max, int decimals)
            : base(new[] { typeof(decimal) })
        {
            _min = min;
            _max = max;
            _decimals = decimals;
        }


        public override object NextValue(IGenerateContext generateContext)
        {
            // Perform arithmetic in double type to avoid overflowing
            var range = (double)_max - (double)_min;
            var sample = _random.NextDouble();
            var scaled = (sample * range) + (double)_min;

            return _decimals.HasValue
                ? Math.Round((decimal)scaled, _decimals.Value)
                : (decimal)scaled;
        }
    }

    public static class DecimalSourceExtensions
    {
        public static MemberConfigurationBuilder<TEntity, decimal> DecimalSource<TEntity>(this MemberConfigurationBuilder<TEntity, decimal> builder, decimal min, decimal max)
        {
            builder.DataSource(() => new DecimalSource(min, max));
            return builder;
        }

        public static MemberConfigurationBuilder<TEntity, decimal> DecimalSource<TEntity>(this MemberConfigurationBuilder<TEntity, decimal> builder, decimal min, decimal max, int decimals)
        {
            builder.DataSource(() => new DecimalSource(min, max, decimals));
            return builder;
        }
    }

}
