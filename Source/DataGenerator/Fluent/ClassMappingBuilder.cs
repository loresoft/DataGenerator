using System;
using System.Linq.Expressions;

namespace DataGenerator.Fluent
{
    /// <summary>
    /// Fluent builder for <see cref="ClassMapping"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class ClassMappingBuilder<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassMappingBuilder{TEntity}"/> class.
        /// </summary>
        protected ClassMappingBuilder()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassMappingBuilder{TEntity}"/> class.
        /// </summary>
        /// <param name="classMapping">The class mapping.</param>
        public ClassMappingBuilder(ClassMapping classMapping)
        {
            ClassMapping = classMapping;
        }

        /// <summary>
        /// Gets or sets the class mapping.
        /// </summary>
        /// <value>
        /// The class mapping.
        /// </value>
        public ClassMapping ClassMapping { get; protected set; }


        /// <summary>
        /// Sets a value indicating whether to automatic map properties of the class.
        /// </summary>
        /// <param name="value"><c>true</c> to automatic map properties; otherwise, <c>false</c>.</param>
        /// <returns>A fluent builder for class mapping.</returns>
        public ClassMappingBuilder<TEntity> AutoMap(bool value = true)
        {
            ClassMapping.AutoMap = value;
            return this;
        }

        /// <summary>
        /// Sets the instance creation factory <see langword="delegate" />.
        /// </summary>
        /// <param name="factory">The instance creation factory.</param>
        /// <returns>
        /// A fluent builder for class mapping.
        /// </returns>
        public ClassMappingBuilder<TEntity> Factory(Func<Type, object> factory)
        {
            ClassMapping.Factory = factory;
            return this;
        }


        /// <summary>
        /// Start a fluent configuration for the specified <paramref name="property"/>.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The source property to configure.</param>
        /// <returns>A fluent member builder for the specified property.</returns>
        public MemberConfigurationBuilder<TEntity, TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            var propertyAccessor = ClassMapping.TypeAccessor.FindProperty(property);

            var memberMapping = ClassMapping.Members.Find(m => m.MemberAccessor.MemberInfo == propertyAccessor.MemberInfo);
            if (memberMapping == null)
            {
                memberMapping = new MemberMapping();
                memberMapping.MemberAccessor = propertyAccessor;

                ClassMapping.Members.Add(memberMapping);
            }

            var builder = new MemberConfigurationBuilder<TEntity, TProperty>(memberMapping);
            return builder;
        }
    }
}