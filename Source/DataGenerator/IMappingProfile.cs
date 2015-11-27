using System;

namespace DataGenerator
{
    public interface IMappingProfile
    {
        Type EntityType { get; }
        void Register(ClassMapping classMapping);
    }
}