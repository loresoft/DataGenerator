using System;
using System.Globalization;

namespace DataGenerator.Sources
{
    public class StreetSource : DataSourceMatchName
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _names = { "Street", "Street1", "Address", "Address1", "AddressLine1" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly string[] _suffix = { "AVE", "BLVD", "CTR", "CIR", "CT", "DR", "HWY", "LN", "PKWY", "ST" };
        private static readonly string[] _streets =
        {
            "Second", "Third", "First", "Fourth", "Park", "Fifth", "Main",
            "Sixth", "Oak", "Seventh", "Pine", "Maple", "Cedar", "Eighth",
            "Elm", "View", "Washington", "Ninth", "Lake", "Hill"
        };

        public StreetSource() : base(_types, _names)
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            string street = _streets[_random.Next(0, _streets.Length)];
            string number = _random.Next(10, 8000).ToString(CultureInfo.InvariantCulture);
            string suffix = _suffix[_random.Next(0, _suffix.Length)];

            return $"{number} {street} {suffix}";
        }

    }
}
