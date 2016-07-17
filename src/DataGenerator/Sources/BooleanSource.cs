using System;
using System.Collections.Generic;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Data source for boolean values
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourcePropertyType" />
    public class BooleanSource : DataSourcePropertyType
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanSource"/> class.
        /// </summary>
        public BooleanSource() 
            : base(new[] { typeof(bool) })
        {
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
            return RandomGenerator.Current.Next(2) == 1;
        }
    }
}
