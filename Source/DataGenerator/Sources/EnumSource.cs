using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Sources
{
    public class EnumSource : IDataSource
    {
        private static readonly Random _random = new Random();

        public int Priority { get; } = int.MaxValue;

        public bool TryMap(IMappingContext mappingContext)
        {
            var memberType = mappingContext?.MemberMapping?.MemberAccessor?.MemberType;
            return memberType?.IsEnum == true;
        }

        public object NextValue(IGenerateContext generateContext)
        {
            var values = Enum.GetValues(generateContext.MemberType);
            var index = _random.Next(values.Length);

            return values.GetValue(index);
        }
    }
}
