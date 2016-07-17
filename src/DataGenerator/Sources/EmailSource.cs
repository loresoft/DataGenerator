using System;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Email address data source generator
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
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

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSource"/> class.
        /// </summary>
        public EmailSource() : this(null)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSource"/> class.
        /// </summary>
        /// <param name="domain">The domain.</param>
        public EmailSource(string domain) : base(_types, _names)
        {
            _domain = domain;
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
            int i = RandomGenerator.Current.Next(0, _domains.Length);
            string name = PasswordSource.Generate(8);
            string domain = string.IsNullOrEmpty(_domain)
                ? _domains[i]
                : _domain.Trim();

            return string.Format("{0}{1}@{2}", name, _index++, domain);
        }

    }
}
