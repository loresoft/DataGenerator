using System;

namespace DataGenerator.Sources
{
    public class FloatSource : DataSourcePropertyType
    {
        private static readonly Random _random = new Random();

        private readonly float _min;
        private readonly float _max;
        private readonly int? _decimals;


        public FloatSource()
            : this(0, 1000000, 2)
        {
        }

        public FloatSource(float min, float max)
            : this(min, max, 0)
        {
        }

        public FloatSource(float min, float max, int decimals)
            : base(new[] { typeof(float), typeof(double) })
        {
            _min = min;
            _max = max;
            _decimals = decimals;
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            // Perform arithmetic in double type to avoid overflowing
            var range = (double)_max - _min;
            var sample = _random.NextDouble();
            var scaled = (sample * range) + _min;

            return _decimals == null
                ? (float)scaled
                : Math.Round(scaled, _decimals.Value);
        }
    }
}
