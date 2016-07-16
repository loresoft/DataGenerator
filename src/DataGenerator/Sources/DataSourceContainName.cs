using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Sources
{
    public abstract class DataSourceContainName : DataSourcePropertyType
    {
        protected DataSourceContainName(IEnumerable<Type> types, IEnumerable<string> names)
            : this(DataSourceBase.MatchNamePriority, types, names)
        {
        }

        protected DataSourceContainName(int priority, IEnumerable<Type> types, IEnumerable<string> names)
            : base(priority, types)
        {
            Names = names;
        }

        public IEnumerable<string> Names { get; }

        public override bool TryMap(IMappingContext mappingContext)
        {
            var name = mappingContext?.MemberMapping?.MemberAccessor?.Name ?? string.Empty;
            return base.TryMap(mappingContext)
                   && Names.Any(n => name.IndexOf(n, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}