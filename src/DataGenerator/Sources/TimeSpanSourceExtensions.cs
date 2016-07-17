using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    /// <summary>
    /// <see cref="TimeSpan"/> data source extension methods
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.TimeSpanSource" />
    public static class TimeSpanSourceExtensions
    {
        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.TimeSpanSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, TimeSpan> TimeSpanSource<TEntity>(this MemberConfigurationBuilder<TEntity, TimeSpan> builder, TimeSpan min, TimeSpan max)
        {
            builder.DataSource(() => new TimeSpanSource(min, max));
            return builder;
        }
    }
}