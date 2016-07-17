using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    /// <summary>
    /// <see cref="DateTime"/> data source extension methods
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DateTimeSource" />
    public static class DateTimeSourceExtensions
    {
        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.DateTimeSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, DateTime> DateTimeSource<TEntity>(this MemberConfigurationBuilder<TEntity, DateTime> builder, DateTime min, DateTime max)
        {
            builder.DataSource(() => new DateTimeSource(min, max));
            return builder;
        }

        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.DateTimeSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, DateTimeOffset> DateTimeSource<TEntity>(this MemberConfigurationBuilder<TEntity, DateTimeOffset> builder, DateTime min, DateTime max)
        {
            builder.DataSource(() => new DateTimeSource(min, max));
            return builder;
        }
    }
}