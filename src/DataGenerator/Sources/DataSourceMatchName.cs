using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Sources
{
    public abstract class DataSourceMatchName : DataSourcePropertyType
    {
        protected DataSourceMatchName(IEnumerable<Type> types, IEnumerable<string> names)
            : this(DataSourceBase.MatchNamePriority, types, names)
        {
        }

        protected DataSourceMatchName(int priority, IEnumerable<Type> types, IEnumerable<string> names)
            : base(priority, types)
        {
            Names = names;
        }

        public IEnumerable<string> Names { get; }

        public override bool TryMap(IMappingContext mappingContext)
        {
            var name = mappingContext?.MemberMapping?.MemberAccessor?.Name;
            return base.TryMap(mappingContext)
                   && Names.Any(n => string.Equals(name, n, StringComparison.OrdinalIgnoreCase));
        }
    }
}