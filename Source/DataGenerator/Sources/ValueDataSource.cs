using System;

namespace DataGenerator.Sources
{
    public class ValueDataSource<T> : IDataSource
    {
        public ValueDataSource(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public int Priority { get; } = int.MaxValue;

        public bool TryMap(IMappingContext mappingContext)
        {
            return false;
        }

        public object NextValue(IGenerateContext generateContext)
        {
            return Value;
        }
    }
}