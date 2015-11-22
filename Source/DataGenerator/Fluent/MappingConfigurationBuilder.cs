using System;
using System.Linq.Expressions;

namespace DataGenerator.Fluent
{
    public class MappingConfigurationBuilder<TEntity>
    {
        public MappingConfigurationBuilder(ClassMapping classMapping)
        {
            ClassMapping = classMapping;
        }

        public ClassMapping ClassMapping { get; }
        
        public MemberConfigurationBuilder<TEntity, TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> sourceProperty)
        {
            var propertyAccessor = ClassMapping.TypeAccessor.FindProperty(sourceProperty);

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