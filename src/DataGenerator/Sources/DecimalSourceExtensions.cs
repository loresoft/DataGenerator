using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    /// <summary>
    /// <see cref="Decimal"/> data source extension methods
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DecimalSource" />
    public static class DecimalSourceExtensions
    {
        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.DecimalSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, decimal> DecimalSource<TEntity>(this MemberConfigurationBuilder<TEntity, decimal> builder, decimal min, decimal max)
        {
            builder.DataSource(() => new DecimalSource(min, max));
            return builder;
        }

        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.DecimalSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="decimals">The number of decimal places.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, decimal> DecimalSource<TEntity>(this MemberConfigurationBuilder<TEntity, decimal> builder, decimal min, decimal max, int decimals)
        {
            builder.DataSource(() => new DecimalSource(min, max, decimals));
            return builder;
        }
    }
}