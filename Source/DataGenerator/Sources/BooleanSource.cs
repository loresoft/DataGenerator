using System;
using System.Collections.Generic;

namespace DataGenerator.Sources
{
    public class BooleanSource : DataSourcePropertyType
    {
        private static readonly Random _random = new Random();

        public BooleanSource() 
            : base(new[] { typeof(bool) })
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            return _random.Next(2) == 1;
        }
    }
}
