using System;
using System.Text;

namespace DataGenerator.Sources
{
    public class PasswordSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Password", "UserPassword" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly char[] _vowels = { 'a', 'e', 'i', 'o', 'u' };
        private static readonly char[] _consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 's', 't', 'v' };
        private static readonly char[] _doubleConsonants = { 'c', 'd', 'f', 'g', 'l', 'm', 'n', 'p', 'r', 's', 't' };

        private readonly int _length;

        public PasswordSource()
            : this(8)
        {
        }

        public PasswordSource(int length) : base(_types, _names)
        {
            _length = length;
        }


        public override object NextValue(IGenerateContext generateContext)
        {
            return Generate(_length);
        }


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
