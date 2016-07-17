using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Money data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceContainName" />
    public class MoneySource : DataSourceContainName
    {
        private static readonly string[] _names = { "Amount", "Cost", "Rate" };
        private static readonly Type[] _types = { typeof(decimal), typeof(double) };

        private readonly decimal _min;
        private readonly decimal _max;
        private readonly int _decimals;


        /// <summary>
        /// Initializes a new instance of the <see cref="MoneySource"/> class.
        /// </summary>
        public MoneySource()
            : this(0, 10000, 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneySource"/> class.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        public MoneySource(decimal min, decimal max)
            : this(min, max, 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneySource"/> class.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="decimals">The number of decimal places.</param>
        public MoneySource(decimal min, decimal max, int decimals)
            : base(_types, _names)
        {
            _min = min;
            _max = max;
            _decimals = decimals;
        }


        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public override object NextValue(IGenerateContext generateContext)
        {
            // Perform arithmetic in double type to avoid overflowing
            var range = (double)_max - (double)_min;
            var sample = RandomGenerator.Current.NextDouble();
            var scaled = (sample * range) + (double)_min;

            return Math.Round((decimal)scaled, _decimals);
        }

    }
}
