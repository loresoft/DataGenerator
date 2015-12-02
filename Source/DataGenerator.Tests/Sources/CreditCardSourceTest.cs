using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Sources;
using FluentAssertions;
using Xunit;

namespace DataGenerator.Tests.Sources
{
    public class CreditCardSourceTest
    {
        [Fact]
        public void GenerateAndValidateNumber()
        {
            for (int i = 0; i < 100; i++)
            {
                var cardNumber = CreditCardSource.GenerateNumber(CreditCardSource.CreditCardType.Visa);
                cardNumber.Should().NotBeNullOrEmpty();
                cardNumber.Length.Should().Be(16);

                var valid = CreditCardSource.IsValidNumber(cardNumber);
                valid.Should().BeTrue(); 
            }
        }
    }
}
