using System;

namespace DataGenerator
{
    public interface IMappingContext    
    {
        ClassMapping ClassMapping { get; }

        MemberMapping MemberMapping { get; }
    }
}