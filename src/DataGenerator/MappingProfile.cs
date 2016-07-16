using System;
using DataGenerator.Fluent;

namespace DataGenerator
{
    /// <summary>
    /// A <see langword="base"/> class for creating mapping profiles
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class MappingProfile<TEntity> : ClassMappingBuilder<TEntity>, IMappingProfile
        where TEntity : class
    {
        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        Type IMappingProfile.EntityType => typeof(TEntity);

        /// <summary>
        /// Registers the specified class mapping.
        /// </summary>
        /// <param name="classMapping">The class mapping.</param>
        void IMappingProfile.Register(ClassMapping classMapping)
        {
            ClassMapping = classMapping;
            Configure();
        }


        /// <summary>
        /// Configure the <typeparamref name="TEntity"/> mapping information.
        /// </summary>
        public abstract void Configure();
    }
}