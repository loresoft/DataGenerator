using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Sources
{
    public abstract class DataSourcePropertyType : DataSourceBase
    {
        protected DataSourcePropertyType(IEnumerable<Type> types) 
            : this(DataSourceBase.PropertyTypePriority, types)
        {
        }

        protected DataSourcePropertyType(int priority, IEnumerable<Type> types) 
            : base(priority)
        {
            if (types == null)
                throw new ArgumentNullException(nameof(types));

            Types = types;
        }

        public IEnumerable<Type> Types { get; }


        public override bool TryMap(IMappingContext mappingContext)
        {
            var memberType = mappingContext?.MemberMapping?.MemberAccessor?.MemberType;
            return Types.Any(t => t == memberType);
        }
    }
}