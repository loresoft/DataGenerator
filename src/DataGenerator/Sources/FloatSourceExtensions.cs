using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
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