using System;

namespace DataGenerator.Sources
{
    public class ValueSource<T> : IDataSource
    {
        public ValueSource(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public object NextValue(IGenerateContext generateContext)
        {
            return Value;
        }
    }
}