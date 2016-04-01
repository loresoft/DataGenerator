using System;
using System.Globalization;

namespace DataGenerator.Sources
{
    public class PhoneSource : DataSourceContainName
    {
        public const string DefaultFormat = "({0}) {1}-{2}";

        private static readonly string[] _names = { "Phone", "Fax", "Mobile" };
        private static readonly Type[] _types = { typeof(string) };
        private readonly string _format;

        public PhoneSource() : this(DefaultFormat)
        { }

        public PhoneSource(string format) : base(_types, _names)
        {
            _format = format ?? DefaultFormat;
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            string areaCode = RandomGenerator.Current.Next(100, 999).ToString(CultureInfo.InvariantCulture);
            string exchange = RandomGenerator.Current.Next(100, 999).ToString(CultureInfo.InvariantCulture);
            string number = RandomGenerator.Current.Next(1, 9999).ToString(CultureInfo.InvariantCulture).PadLeft(4, '0');

            return string.Format(_format, areaCode, exchange, number);
        }

    }
}