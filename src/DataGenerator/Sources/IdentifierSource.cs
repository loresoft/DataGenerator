using System;

namespace DataGenerator.Sources
{
    public class IdentifierSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Id" };
        private static readonly Type[] _types = { typeof(string) };

        public IdentifierSource() : base(_types, _names)
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            return Guid.NewGuid().ToString();
        }

    }
}