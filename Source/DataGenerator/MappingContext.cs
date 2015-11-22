using System;

namespace DataGenerator
{
    public class MappingContext : IMappingContext
    {
        public MappingContext(ClassMapping classMapping, MemberMapping memberMapping)
        {
            ClassMapping = classMapping;
            MemberMapping = memberMapping;
        }

        public ClassMapping ClassMapping { get; }

        public MemberMapping MemberMapping { get; }

    }
}