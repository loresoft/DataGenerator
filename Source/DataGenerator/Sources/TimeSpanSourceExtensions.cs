using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    public static class TimeSpanSourceExtensions
    {
        public static MemberConfigurationBuilder<TEntity, TimeSpan> TimeSpanSource<TEntity>(this MemberConfigurationBuilder<TEntity, TimeSpan> builder, TimeSpan min, TimeSpan max)
        {
            builder.DataSource(() => new TimeSpanSource(min, max));
            return builder;
        }
    }
}