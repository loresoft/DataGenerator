using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    public class FloatSource : DataSourcePropertyType
    {
        private static readonly Random _random = new Random();

        private readonly float _min;
        private readonly float _max;
        private readonly int? _decimals;


        public FloatSource()
            : this(0, 1000000, 2)
        {
        }

        public FloatSource(float min, float max)
            : this(min, max, 0)
        {
        }

        public FloatSource(float min, float max, int decimals)
            : base(new[] { typeof(float), typeof(double) })
        {
            _min = min;
            _max = max;
            _decimals = decimals;
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            // Perform arithmetic in double type to avoid overflowing
            var range = (double)_max - _min;
            var sample = _random.NextDouble();
            var scaled = (sample * range) + _min;

            return _decimals == null
                ? (float)scaled
                : Math.Round(scaled, _decimals.Value);
        }
    }

    public static class FloatSourceExtensions
    {
        public static MemberConfigurationBuilder<TEntity, float> FloatSource<TEntity>(this MemberConfigurationBuilder<TEntity, float> builder, float min, float max)
        {
            builder.DataSource(() => new FloatSource(min, max));
            return builder;
        }

        public static MemberConfigurationBuilder<TEntity, float> FloatSource<TEntity>(this MemberConfigurationBuilder<TEntity, float> builder, float min, float max, int decimals)
        {
            builder.DataSource(() => new FloatSource(min, max, decimals));
            return builder;
        }

        public static MemberConfigurationBuilder<TEntity, double> FloatSource<TEntity>(this MemberConfigurationBuilder<TEntity, double> builder, float min, float max)
        {
            builder.DataSource(() => new FloatSource(min, max));
            return builder;
        }

        public static MemberConfigurationBuilder<TEntity, double> FloatSource<TEntity>(this MemberConfigurationBuilder<TEntity, double> builder, float min, float max, int decimals)
        {
            builder.DataSource(() => new FloatSource(min, max, decimals));
            return builder;
        }
    }


}
