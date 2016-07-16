using System;
using DataGenerator.Sources;
using Xunit;
using Xunit.Abstractions;

namespace DataGenerator.Tests.Sources
{
    public class LoremIpsumSourceTest
    {
        private readonly ITestOutputHelper _output;

        public LoremIpsumSourceTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void NextValue()
        {
            var source = new LoremIpsumSource();

            for (int i = 0; i < 10; i++)
            {
                var nextValue = source.NextValue(null);
                _output.WriteLine($"Value {i}:\r\n{nextValue}\r\n\r\n");
            }
        }


        [Fact]
        public void NextValueLong()
        {
            var source = new LoremIpsumSource(1000);

            var nextValue = source.NextValue(null);
            _output.WriteLine($"Text:\r\n{nextValue}\r\n\r\n");
        }
    }
}
