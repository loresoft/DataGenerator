using System;
using System.Collections.Generic;

namespace DataGenerator.Sources
{
    public class BooleanSource : DataSourcePropertyType
    {
        public BooleanSource() 
            : base(new[] { typeof(bool) })
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            return RandomGenerator.Current.Next(2) == 1;
        }
    }
}
