using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Sources
{

    /// <summary>
    /// Social Security data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
    public class SocialSecuritySource : DataSourceMatchName
    {
        private static readonly string[] _names = { "SocialSecurityNumber", "SocialSecurity", "SSN", "TaxIdentifier" };
        private static readonly Type[] _types = { typeof(string) };

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialSecuritySource"/> class.
        /// </summary>
        public SocialSecuritySource() : base(_types, _names)
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
            var area = RandomGenerator.Current.Next(1, 899);
            var group = RandomGenerator.Current.Next(1, 99);
            var series = RandomGenerator.Current.Next(1, 9999);

            return $"{area:000}-{group:00}-{series:0000}";
        }
    }
}
