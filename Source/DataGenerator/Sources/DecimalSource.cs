using System;

namespace DataGenerator.Sources
{
    public class DecimalSource : DataSourcePropertyType
    {
        private readonly decimal _min;
        private readonly decimal _max;
        private readonly int? _decimals;


        public DecimalSource()
            : this(0, 1000000, 2)
        {
        }

        public DecimalSource(decimal min, decimal max)
            : this(min, max, 0)
        {
        }

        public DecimalSource(decimal min, decimal max, int decimals)
            : base(new[] { typeof(decimal) })
        {
            _min = min;
            _max = max;
            _decimals = decimals;
        }


        public override object NextValue(IGenerateContext generateContext)
        {
            // Perform arithmetic in double type to avoid overflowing
            var range = (double)_max - (double)_min;
            var sample = RandomGenerator.Current.NextDouble();
            var scaled = (sample * range) + (double)_min;

            return _decimals.HasValue
                ? Math.Round((decimal)scaled, _decimals.Value)
                : (decimal)scaled;
        }
    }
}
