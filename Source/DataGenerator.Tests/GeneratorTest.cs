using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Sources;
using DataGenerator.Tests.Models;
using FluentAssertions;
using Xunit;

namespace DataGenerator.Tests
{
    public class GeneratorTest
    {
        [Fact]
        public void Configure()
        {
            Generator.Configuration.Mapping.Clear();
            Generator.Configure(c => c
                .Entity<User>(m => m
                    .AutoMap()
                    .Map(e => {
                        e.Property(p => p.FirstName).DataSource<FirstNameSource>();
                        e.Property(p => p.LastName).DataSource<LastNameSource>();
                        e.Property(p => p.Address1).DataSource<StreetSource>();
                        e.Property(p => p.City).DataSource<CitySource>();
                        e.Property(p => p.State).DataSource<StateSource>();
                        e.Property(p => p.Zip).DataSource<PostalCodeSource>();

                        // metadata
                        e.Property(p => p.Note).DataSource<LoremIpsumSource>();
                        e.Property(p => p.Password).DataSource<PasswordSource>();

                        // array of values
                        e.Property(p => p.Status).DataSource(new[] { Status.New, Status.Verified });

                        
                        // don't generate
                        e.Property(p => p.Budget).Ignore();

                        // static value
                        e.Property(p => p.IsActive).Value(true);

                        // delegate value
                        e.Property(p => p.Created).Value(() => DateTime.Now);

                        // repeat call
                        e.Property(p => p.Created).Value(() => DateTime.Now);
                    })
                )
            );

            Generator.Configuration.Mapping.Count.Should().Be(1);

            var classMapping = Generator.Configuration.Mapping.First();
            classMapping.Should().NotBeNull();

            classMapping.Value.Members.Count.Should().Be(12);

            var instance = Generator.Single<User>();
            instance.Should().NotBeNull();
            instance.FirstName.Should().NotBeNull();
            instance.LastName.Should().NotBeNull();
            instance.Address1.Should().NotBeNull();
            instance.City.Should().NotBeNull();
            instance.State.Should().NotBeNull();
            instance.Zip.Should().NotBeNull();
            instance.Note.Should().NotBeNull();
            instance.Password.Should().NotBeNull();
        }

        [Fact]
        public void GenerateAutoMap()
        {
            Generator.Configuration.Mapping.Clear();
            var instance = Generator.Single<User>();
            instance.Should().NotBeNull();
            instance.FirstName.Should().NotBeNull();
        }
    }

    
}
