using System;
using DataGenerator.Fluent;

namespace DataGenerator.Sources
{
    /// <summary>
    /// <see cref="Single"/> and <see cref="Double"/> data source extension methods
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.FloatSource" />
    public static class FloatSourceExtensions
    {
        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.FloatSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, float> FloatSource<TEntity>(this MemberConfigurationBuilder<TEntity, float> builder, float min, float max)
        {
            builder.DataSource(() => new FloatSource(min, max));
            return builder;
        }

        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.FloatSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="decimals">The number of decimal places.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, float> FloatSource<TEntity>(this MemberConfigurationBuilder<TEntity, float> builder, float min, float max, int decimals)
        {
            builder.DataSource(() => new FloatSource(min, max, decimals));
            return builder;
        }

        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.FloatSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, double> FloatSource<TEntity>(this MemberConfigurationBuilder<TEntity, double> builder, float min, float max)
        {
            builder.DataSource(() => new FloatSource(min, max));
            return builder;
        }

        /// <summary>
        /// Use the <see cref="DataGenerator.Sources.FloatSource"/> data source with the specified <paramref name="min"/> and <paramref name="max"/> values
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The member configuration builder.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="decimals">The number of decimal places.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public static MemberConfigurationBuilder<TEntity, double> FloatSource<TEntity>(this MemberConfigurationBuilder<TEntity, double> builder, float min, float max, int decimals)
        {
            builder.DataSource(() => new FloatSource(min, max, decimals));
            return builder;
        }
    }
}