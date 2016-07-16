using System;

namespace DataGenerator.Sources
{
    public class GuidSource : DataSourcePropertyType
    {
        private static readonly Type[] _types = { typeof(Guid) };

        public GuidSource() : base(_types)
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            return Guid.NewGuid();
        }

    }
}