using System;

namespace DataGenerator.Fluent
{
    public class ClassMappingBuilder<TEntity>
    {
        public ClassMappingBuilder(ClassMapping classMapping)
        {
            ClassMapping = classMapping;
        }

        public ClassMapping ClassMapping { get; }

        public ClassMappingBuilder<TEntity> AutoMap(bool value = true)
        {
            ClassMapping.AutoMap = value;
            return this;
        }

        public ClassMappingBuilder<TEntity> Map(Action<MappingConfigurationBuilder<TEntity>> builder)
        {
            var mappingBuilder = new MappingConfigurationBuilder<TEntity>(ClassMapping);
            builder(mappingBuilder);

            return this;
        }
    }
}