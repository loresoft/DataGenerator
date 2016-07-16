using System;

namespace DataGenerator.Sources
{
    public class EmailSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "EmailAddress", "Email" };
        private static readonly Type[] _types = { typeof(string) };
        private static readonly string[] _domains = {
            "gmail.com",
            "msn.com",
            "outlook.com",
            "hotmail.com",
            "aol.com",
            "yahoo.com"
        };

        private int _index;
        private readonly string _domain = "";

        public EmailSource() : this(null)
        {
        }

        public EmailSource(string domain) : base(_types, _names)
        {
            _domain = domain;
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            string name = PasswordSource.Generate(8);
            string domain = string.IsNullOrEmpty(_domain)
                ? _domains[RandomGenerator.Current.Next(0, _domains.Length)]
                : _domain.Trim();

            return string.Format("{0}{1}@{2}", name, _index++, domain);
        }

    }
}
