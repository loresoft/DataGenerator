using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Sources
{
    /// <summary>
    /// A base class for data source property names pattern match
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourcePropertyType" />
    public abstract class DataSourceContainName : DataSourcePropertyType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceContainName"/> class.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="names">The names.</param>
        protected DataSourceContainName(IEnumerable<Type> types, IEnumerable<string> names)
            : this(DataSourceBase.MatchNamePriority, types, names)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceContainName"/> class.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="types">The types.</param>
        /// <param name="names">The names.</param>
        protected DataSourceContainName(int priority, IEnumerable<Type> types, IEnumerable<string> names)
            : base(priority, types)
        {
            Names = names;
        }

        /// <summary>
        /// Gets the name patterns this data source will generate values for.
        /// </summary>
        /// <value>
        /// The name patterns this data source will generate values for..
        /// </value>
        public IEnumerable<string> Names { get; }


        /// <summary>
        /// Test if the current <paramref name="mappingContext" /> can use this data source.
        /// </summary>
        /// <param name="mappingContext">The mapping context.</param>
        /// <returns>
        ///   <c>true</c> if this data source can be used; otherwise <c>false</c>.
        /// </returns>
        public override bool TryMap(IMappingContext mappingContext)
        {
            var name = mappingContext?.MemberMapping?.MemberAccessor?.Name ?? string.Empty;
            return base.TryMap(mappingContext)
                   && Names.Any(n => name.IndexOf(n, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}