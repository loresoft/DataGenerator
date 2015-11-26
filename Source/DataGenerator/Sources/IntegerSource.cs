using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    public class IntegerSource : DataSourcePropertyType
    {
        private static readonly Random _random = new Random();

        private readonly int _min;
        private readonly int _max;


        public IntegerSource()
            : this(0, short.MaxValue)
        {
        }

        public IntegerSource(int min, int max)
            : base(new[] { typeof(short), typeof(int), typeof(long) })
        {
            _min = min;
            _max = max;
        }


        public override object NextValue(IGenerateContext generateContext)
        {
            return _random.Next(_min, _max);
        }
    }

    public static class IntegerSourceExtensions
    {
        public static MemberConfigurationBuilder<TEntity, short> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, short> builder, short min, short max)
        {
            builder.DataSource(() => new IntegerSource(1, 10));
            return builder;
        }

        public static MemberConfigurationBuilder<TEntity, int> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, int> builder, int min, int max)
        {
            builder.DataSource(() => new IntegerSource(1, 10));
            return builder;
        }

        public static MemberConfigurationBuilder<TEntity, double> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, double> builder, int min, int max)
        {
            builder.DataSource(() => new IntegerSource(1, 10));
            return builder;
        }

        public static MemberConfigurationBuilder<TEntity, decimal> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, decimal> builder, int min, int max)
        {
            builder.DataSource(() => new IntegerSource(1, 10));
            return builder;
        }
    }
}
