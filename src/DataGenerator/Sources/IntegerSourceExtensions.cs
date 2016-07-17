using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.IntegerSource"/>
    public static class IntegerSourceExtensions
    {
        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.IntegerSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>

        public static MemberConfigurationBuilder<TEntity, short> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, short> builder, short min, short max)
        {
            builder.DataSource(() => new IntegerSource(min, max));
            return builder;
        }

        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.IntegerSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, int> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, int> builder, int min, int max)
        {
            builder.DataSource(() => new IntegerSource(min, max));
            return builder;
        }

        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.IntegerSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, double> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, double> builder, int min, int max)
        {
            builder.DataSource(() => new IntegerSource(min, max));
            return builder;
        }

        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.IntegerSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, decimal> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, decimal> builder, int min, int max)
        {
            builder.DataSource(() => new IntegerSource(min, max));
            return builder;
        }
    }
}