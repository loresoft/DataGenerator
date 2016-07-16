using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
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