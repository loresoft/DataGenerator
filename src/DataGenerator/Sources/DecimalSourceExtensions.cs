using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
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