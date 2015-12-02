using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Extensions;

namespace DataGenerator.Sources
{
    public class CreditCardSource : DataSourceMatchName
    {
        public enum CreditCardType
        {
            Visa,
            Mastercard,
            AmericanExpress,
            Discover
        }

        private static readonly Random _random = new Random();
        private static readonly string[] _names = { "CreditCard", "CardNumber" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly List<WeightedValue<CreditCardType>> _cardTypes = new List<WeightedValue<CreditCardType>>
        {
            new WeightedValue<CreditCardType>(CreditCardType.Visa, 3),
            new WeightedValue<CreditCardType>(CreditCardType.Mastercard, 3),
            new WeightedValue<CreditCardType>(CreditCardType.AmericanExpress, 2),
            new WeightedValue<CreditCardType>(CreditCardType.Discover, 1),
        };

        public CreditCardSource() : base(_types, _names)
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            // random card type
            var type = _cardTypes.Random(p => p.Weight);
            return GenerateNumber(type);
        }



        /// <summary>
        /// Generates a random credit card number.
        /// </summary>
        /// <param name="cardType">Type of the credit card.</param>
        /// <returns></returns>
        public static string GenerateNumber(CreditCardType cardType)
        {
            int pos = 0;
            int[] number = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int sum = 0;
            int finalDigit = 0;
            int lenOffset = 0;
            int len = 0;

            // Fill in the first values of the string based with the specified bank's prefix.
            switch (cardType)
            {
                case CreditCardType.Visa:
                    number[0] = 4;
                    pos = 1;
                    len = 16;
                    break;
                case CreditCardType.Mastercard:
                    number[0] = 5;
                    number[1] = _random.Next(1, 5); // Between 1 and 5.
                    pos = 2;
                    len = 16;
                    break;
                case CreditCardType.AmericanExpress:
                    number[0] = 3;
                    number[1] = _random.Next(4, 7); // Between 4 and 7.
                    pos = 2;
                    len = 15;
                    break;
                case CreditCardType.Discover:
                    number[0] = 6;
                    number[1] = 0;
                    number[2] = 1;
                    number[3] = 1;
                    pos = 4;
                    len = 16;
                    break;
            }

            // Fill all the remaining numbers except for the last one with random values.
            while (pos < len - 1)
                number[pos++] = _random.Next(0, 9);

            // Calculate the Luhn checksum of the values thus far.
            lenOffset = (len + 1) % 2;
            for (pos = 0; pos < len - 1; pos++)
            {
                if ((pos + lenOffset) % 2 != 0)
                {
                    var t = number[pos] * 2;
                    if (t > 9)
                        t -= 9;
                    sum += t;
                }
                else
                {
                    sum += number[pos];
                }
            }

            // Choose the last digit so that it causes the entire string to pass the checksum.
            finalDigit = (10 - (sum % 10)) % 10;
            number[len - 1] = finalDigit;

            var buffer = new StringBuilder();
            foreach (var n in number)
                buffer.Append(n);

            return buffer.ToString();
        }

        /// <summary>
        /// Determines whether the credit card number is valid.
        /// </summary>
        /// <param name="number">The credit card number.</param>
        /// <returns></returns>
        /// <remarks>
        /// Extremely fast Luhn algorithm implementation, based on
        /// pseudo code from Cliff L. Biffle (http://microcoder.livejournal.com/17175.html)
        /// Copyleft Thomas @ Orb of Knowledge:
        /// http://orb-of-knowledge.blogspot.com/2009/08/extremely-fast-luhn-function-for-c.html
        /// </remarks>
        public static bool IsValidNumber(string number)
        {
            int[] DELTAS = { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
            int checksum = 0;
            char[] chars = number.ToCharArray();
            for (int i = chars.Length - 1; i > -1; i--)
            {
                int j = chars[i] - 48;
                checksum += j;
                if (((i - chars.Length) % 2) == 0)
                    checksum += DELTAS[j];
            }

            return ((checksum % 10) == 0);
        }

    }
}
