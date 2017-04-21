using System;
using System.Diagnostics;
using System.IO;
using CsvHelper;
using DataGenerator.Tests.Models;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace DataGenerator.Tests
{
    public class CsvTest
    {
        private readonly ITestOutputHelper _output;

        public CsvTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GenerateProfile()
        {
            var generator = Generator.Create(c => c
                .ExcludeName("xunit")
                .Profile<UserProfile>()
                .Entity<User>(e => e.Property(p => p.Note).Ignore())
            );


            var count = 10;

            var watch = Stopwatch.StartNew();
            var users = generator.List<User>(count);
            watch.Stop();

            _output.WriteLine("Generate Time: {0} ms", watch.ElapsedMilliseconds);

            users.Should().NotBeNull();

            string fileName = $"Generated Users ({count}) {DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.csv";

            using (var textWriter = File.CreateText(fileName))
            {
                var csv = new CsvWriter(textWriter);
                csv.WriteRecords(users);
                textWriter.Flush();
            }
        }

    }
}