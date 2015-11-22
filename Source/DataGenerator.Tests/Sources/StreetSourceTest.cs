using System;
using DataGenerator.Sources;
using Xunit;
using Xunit.Abstractions;

namespace DataGenerator.Tests.Sources
{
    public class StreetSourceTest
    {
        private readonly ITestOutputHelper _output;

        public StreetSourceTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void NextValue()
        {
            var source = new StreetSource();

            for (int i = 0; i < 10; i++)
            {
                var nextValue = source.NextValue(null);
                _output.WriteLine($"Value {i}: {nextValue}");
            }

        }
    }
}