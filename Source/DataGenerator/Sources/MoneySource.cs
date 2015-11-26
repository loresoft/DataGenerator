using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Sources
{
    public class MoneySource : DataSourceContainName
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _names = { "Amount", "Cost", "Rate" };
        private static readonly Type[] _types = { typeof(decimal), typeof(double) };

        private readonly decimal _min;
        private readonly decimal _max;
        private readonly int _decimals;


        public MoneySource()
            : this(0, 10000, 2)
        {
        }

        public MoneySource(decimal min, decimal max)
            : this(min, max, 2)
        {
        }

        public MoneySource(decimal min, decimal max, int decimals)
            : base(_types, _names)
        {
            _min = min;
            _max = max;
            _decimals = decimals;
        }


        public override object NextValue(IGenerateContext generateContext)
        {
            // Perform arithmetic in double type to avoid overflowing
            var range = (double)_max - (double)_min;
            var sample = _random.NextDouble();
            var scaled = (sample * range) + (double)_min;

            return Math.Round((decimal)scaled, _decimals);
        }

    }
}
