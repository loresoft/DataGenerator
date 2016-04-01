using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Sources
{
    public class EnumSource : IDataSource
    {
        public int Priority { get; } = int.MaxValue;

        public bool TryMap(IMappingContext mappingContext)
        {
            var memberType = mappingContext?.MemberMapping?.MemberAccessor?.MemberType;
            return memberType?.IsEnum == true;
        }

        public object NextValue(IGenerateContext generateContext)
        {
            var values = Enum.GetValues(generateContext.MemberType);
            var index = RandomGenerator.Current.Next(values.Length);

            return values.GetValue(index);
        }
    }
}
