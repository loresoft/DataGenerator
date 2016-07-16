using System;
using DataGenerator.Sources;
using FluentAssertions;
using Xunit;

namespace DataGenerator.Tests.Sources
{
    public class SocialSecuritySourceTest
    {
        [Fact]
        public void GenerateNextValue()
        {
            var source = new SocialSecuritySource();
            var ssn = source.NextValue(null);
            ssn.Should().NotBeNull();
            ssn.Should().BeOfType<string>();
        }

    }
}