using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Sources
{
    public class SocialSecuritySource : DataSourceMatchName
    {

        private static readonly Random _random = new Random();
        private static readonly string[] _names = { "SocialSecurityNumber", "SocialSecurity", "SSN", "TaxIdentifier" };
        private static readonly Type[] _types = { typeof(string) };

        

        public SocialSecuritySource() : base(_types, _names)
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            var area = _random.Next(1, 899);
            var group = _random.Next(1, 99);
            var series = _random.Next(1, 9999);

            return $"{area:000}-{group:00}-{series:0000}";
        }
    }
}
