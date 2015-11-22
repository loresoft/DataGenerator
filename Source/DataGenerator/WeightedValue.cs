using System;

namespace DataGenerator
{
    public class WeightedValue<T>
    {
        public WeightedValue(T value) : this(value, 1)
        {

        }

        public WeightedValue(T value, int weight)
        {
            Weight = weight;
            Value = value;
        }

        public int Weight { get; }

        public T Value { get; }

        public static implicit operator T(WeightedValue<T> value)
        {
            return value == null ? default(T) : value.Value;
        }
    }
}