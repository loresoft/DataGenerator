using System;
using System.Collections.Generic;
using DataGenerator.Sources;

namespace DataGenerator.Fluent
{
    public class MemberConfigurationBuilder<TEntity, TProperty>
    {

        public MemberConfigurationBuilder(MemberMapping memberMapping)
        {
            MemberMapping = memberMapping;
        }

        public MemberMapping MemberMapping { get; }


        public MemberConfigurationBuilder<TEntity, TProperty> DataSource<TSource>()
            where TSource : class, IDataSource, new()
        {
            var source = new TSource();
            MemberMapping.DataSource = source;

            return this;
        }

        public MemberConfigurationBuilder<TEntity, TProperty> DataSource<TSource>(Func<TSource> factory)
            where TSource : class, IDataSource
        {
            var source = factory();
            MemberMapping.DataSource = source;

            return this;
        }

        public MemberConfigurationBuilder<TEntity, TProperty> DataSource(IEnumerable<TProperty> values)
        {
            var source = new ListDataSource<TProperty>(values);
            MemberMapping.DataSource = source;

            return this;
        }
        

        public MemberConfigurationBuilder<TEntity, TProperty> Ignore(bool value = true)
        {
            MemberMapping.Ignored = value;
            return this;
        }


        public MemberConfigurationBuilder<TEntity, TProperty> Value(Func<TProperty> factory)
        {
            var source = new FactoryDataSource<TProperty>(factory);
            MemberMapping.DataSource = source;

            return this;
        }

        public MemberConfigurationBuilder<TEntity, TProperty> Value(TProperty value)
        {
            var source = new ValueSource<TProperty>(value);
            MemberMapping.DataSource = source;

            return this;
        }
    }
}