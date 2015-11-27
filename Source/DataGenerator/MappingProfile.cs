using System;
using DataGenerator.Fluent;

namespace DataGenerator
{
    public abstract class MappingProfile<TEntity> : ClassMappingBuilder<TEntity>, IMappingProfile
        where TEntity : class
    {
        Type IMappingProfile.EntityType => typeof(TEntity);

        void IMappingProfile.Register(ClassMapping classMapping)
        {
            ClassMapping = classMapping;
            Configure();
        }


        public abstract void Configure();
    }
}