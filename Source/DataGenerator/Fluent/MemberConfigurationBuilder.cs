using System;
using System.Collections.Generic;
using DataGenerator.Sources;

namespace DataGenerator.Fluent
{
    /// <summary>
    /// Fluent builder for an entity property.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    public class MemberConfigurationBuilder<TEntity, TProperty>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberConfigurationBuilder{TEntity, TProperty}"/> class.
        /// </summary>
        /// <param name="memberMapping">The member mapping.</param>
        public MemberConfigurationBuilder(MemberMapping memberMapping)
        {
            MemberMapping = memberMapping;
        }

        /// <summary>
        /// Gets the current member mapping.
        /// </summary>
        /// <value>
        /// The current member mapping.
        /// </value>
        public MemberMapping MemberMapping { get; }


        /// <summary>
        /// Set the properties generation data source to the specified type.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <returns>Fluent builder for an entity property.</returns>
        public MemberConfigurationBuilder<TEntity, TProperty> DataSource<TSource>()
            where TSource : class, IDataSource, new()
        {
            var source = new TSource();
            MemberMapping.DataSource = source;

            return this;
        }

        /// <summary>
        /// Set the properties generation data source to the specified <paramref name="factory"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="factory">The factory delegate used as the data source.</param>
        /// <returns>Fluent builder for an entity property.</returns>
        public MemberConfigurationBuilder<TEntity, TProperty> DataSource<TSource>(Func<TSource> factory)
            where TSource : class, IDataSource
        {
            var source = factory();
            MemberMapping.DataSource = source;

            return this;
        }

        /// <summary>
        /// Set the properties generation data source that uses the specified <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The values to use as the data source.</param>
        /// <returns>
        /// Fluent builder for an entity property.
        /// </returns>
        public MemberConfigurationBuilder<TEntity, TProperty> DataSource(IEnumerable<TProperty> values)
        {
            var source = new ListDataSource<TProperty>(values);
            MemberMapping.DataSource = source;

            return this;
        }

        /// <summary>
        /// Set the properties generation data source that uses the specified <paramref name="values" />.
        /// </summary>
        /// <param name="values">The values to use as the data source.</param>
        /// <param name="weightSelector">The random weight selector delegate.</param>
        /// <returns>
        /// Fluent builder for an entity property.
        /// </returns>
        public MemberConfigurationBuilder<TEntity, TProperty> DataSource(IEnumerable<TProperty> values, Func<TProperty, int> weightSelector)
        {
            var source = new ListDataSource<TProperty>(values);
            source.WeightSelector = weightSelector;

            MemberMapping.DataSource = source;

            return this;
        }


        /// <summary>
        /// Ignore this property during data generation.
        /// </summary>
        /// <param name="value">if set to <c>true</c> this property will be ignored.</param>
        /// <returns>
        /// Fluent builder for an entity property.
        /// </returns>
        public MemberConfigurationBuilder<TEntity, TProperty> Ignore(bool value = true)
        {
            MemberMapping.Ignored = value;
            return this;
        }


        /// <summary>
        /// Use the <paramref name="factory"/> value during data generation.
        /// </summary>
        /// <param name="factory">The factory delegate to get a value from.</param>
        /// <returns>
        /// Fluent builder for an entity property.
        /// </returns>
        public MemberConfigurationBuilder<TEntity, TProperty> Value(Func<TProperty> factory)
        {
            var source = new FactoryDataSource<TProperty>(factory);
            MemberMapping.DataSource = source;

            return this;
        }

        /// <summary>
        /// Use the specified <paramref name="value" /> during data generation.
        /// </summary>
        /// <param name="value">The value to use.</param>
        /// <returns>
        /// Fluent builder for an entity property.
        /// </returns>
        public MemberConfigurationBuilder<TEntity, TProperty> Value(TProperty value)
        {
            var source = new ValueSource<TProperty>(value);
            MemberMapping.DataSource = source;

            return this;
        }
    }
}