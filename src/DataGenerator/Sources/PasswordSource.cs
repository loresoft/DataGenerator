using System;
using System.Text;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Password generator data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
    public class PasswordSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Password", "UserPassword" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly char[] _vowels = { 'a', 'e', 'i', 'o', 'u' };
        private static readonly char[] _consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 's', 't', 'v' };
        private static readonly char[] _doubleConsonants = { 'c', 'd', 'f', 'g', 'l', 'm', 'n', 'p', 'r', 's', 't' };

        private readonly int _length;


        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordSource"/> class.
        /// </summary>
        public PasswordSource()
            : this(8)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordSource"/> class.
        /// </summary>
        /// <param name="length">The password length.</param>
        public PasswordSource(int length) : base(_types, _names)
        {
            _length = length;
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
            return Generate(_length);
        }


        /// <summary>
        /// Generates a password with the specified length.
        /// </summary>
        /// <param name="passwordLength">Length of the password.</param>
        /// <returns>A generated password</returns>
        public static string Generate(int passwordLength)
        {
            bool wroteConsonant = false;
            int counter;
            var password = new StringBuilder();

            for (counter = 0; counter <= passwordLength; counter++)
            {
                if (password.Length > 0 & (wroteConsonant == false) & (RandomGenerator.Current.Next(100) < 10))
                {
                    password.Append(_doubleConsonants[RandomGenerator.Current.Next(_doubleConsonants.Length)], 2);
                    counter += 1;
                    wroteConsonant = true;
                    continue;
                }

                if ((wroteConsonant == false) & (RandomGenerator.Current.Next(100) < 90))
                {
                    password.Append(_consonants[RandomGenerator.Current.Next(_consonants.Length)]);
                    wroteConsonant = true;
                }
                else
                {
                    password.Append(_vowels[RandomGenerator.Current.Next(_vowels.Length)]);
                    wroteConsonant = false;
                }
            }

            password.Length = passwordLength;
            return password.ToString();
        }

    }
}
