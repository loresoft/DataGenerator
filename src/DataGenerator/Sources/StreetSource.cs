using System;
using System.Globalization;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Street data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
    public class StreetSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Street", "Street1", "Address", "Address1", "AddressLine1" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly string[] _suffix = { "AVE", "BLVD", "CTR", "CIR", "CT", "DR", "HWY", "LN", "PKWY", "ST" };
        private static readonly string[] _streets =
        {
            "Second", "Third", "First", "Fourth", "Park", "Fifth", "Main",
            "Sixth", "Oak", "Seventh", "Pine", "Maple", "Cedar", "Eighth",
            "Elm", "View", "Washington", "Ninth", "Lake", "Hill"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="StreetSource"/> class.
        /// </summary>
        public StreetSource() : base(_types, _names)
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
            string street = _streets[RandomGenerator.Current.Next(0, _streets.Length)];
            string number = RandomGenerator.Current.Next(10, 8000).ToString(CultureInfo.InvariantCulture);
            string suffix = _suffix[RandomGenerator.Current.Next(0, _suffix.Length)];

            return $"{number} {street} {suffix}";
        }

    }
}
