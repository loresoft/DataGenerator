using System;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Integer value generator data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourcePropertyType" />
    public class IntegerSource : DataSourcePropertyType
    {
        private readonly int _min;
        private readonly int _max;


        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerSource"/> class.
        /// </summary>
        public IntegerSource()
            : this(0, short.MaxValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerSource"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public IntegerSource(int min, int max)
            : base(new[] { typeof(short), typeof(int), typeof(long) })
        {
            _min = min;
            _max = max;
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
            return RandomGenerator.Current.Next(_min, _max);
        }
    }
}
