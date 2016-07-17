using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Sources
{
    /// <summary>
    /// A base class for data source property types
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceBase" />
    public abstract class DataSourcePropertyType : DataSourceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourcePropertyType"/> class.
        /// </summary>
        /// <param name="types">The types.</param>
        protected DataSourcePropertyType(IEnumerable<Type> types) 
            : this(DataSourceBase.PropertyTypePriority, types)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourcePropertyType"/> class.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="types">The types.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        protected DataSourcePropertyType(int priority, IEnumerable<Type> types) 
            : base(priority)
        {
            if (types == null)
                throw new ArgumentNullException(nameof(types));

            Types = types;
        }

        /// <summary>
        /// Gets the types this data source will generate values for.
        /// </summary>
        /// <value>
        /// The types this data source will generate values for.
        /// </value>
        public IEnumerable<Type> Types { get; }

        /// <summary>
        /// Test if the current <paramref name="mappingContext" /> can use this data source.
        /// </summary>
        /// <param name="mappingContext">The mapping context.</param>
        /// <returns>
        ///   <c>true</c> if this data source can be used; otherwise <c>false</c>.
        /// </returns>
        public override bool TryMap(IMappingContext mappingContext)
        {
            var memberType = mappingContext?.MemberMapping?.MemberAccessor?.MemberType;
            return Types.Any(t => t == memberType);
        }
    }
}