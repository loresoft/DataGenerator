using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DataGenerator.Reflection;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Enum value data source
    /// </summary>
    /// <seealso cref="DataGenerator.IDataSource" />
    public class EnumSource : DataSourceBase
    {
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
            if (memberType == null)
                return false;

            return memberType.GetTypeInfo().IsEnum == true;
        }

        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public override object NextValue(IGenerateContext generateContext)
        {
            var values = Enum.GetValues(generateContext.MemberType);
            var index = RandomGenerator.Current.Next(values.Length);

            return values.GetValue(index);
        }
    }
}
