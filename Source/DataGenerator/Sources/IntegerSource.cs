using System;

namespace DataGenerator.Sources
{
    public class IntegerSource : DataSourcePropertyType
    {
        private static readonly Random _random = new Random();

        private readonly int _min;
        private readonly int _max;


        public IntegerSource()
            : this(0, short.MaxValue)
        {
        }

        public IntegerSource(int min, int max)
            : base(new[] { typeof(short), typeof(int), typeof(long) })
        {
            _min = min;
            _max = max;
        }


        public override object NextValue(IGenerateContext generateContext)
        {
            return _random.Next(_min, _max);
        }
    }
}
