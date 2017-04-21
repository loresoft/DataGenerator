using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
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
            var generator = Generator.Create(c => c
                .ExcludeName("xunit")
                .Entity<User>(e =>
                {
                    e.AutoMap();

                    e.Property(p => p.FirstName).DataSource<FirstNameSource>();
                    e.Property(p => p.LastName).DataSource<LastNameSource>();

                    // to use other properties, must come after there declaration
                    e.Property(p => p.EmailAddress).Value(u => $"{u.FirstName}.{u.LastName}@mailinator.com");

                    e.Property(p => p.Address1).DataSource<StreetSource>();
                    e.Property(p => p.City).DataSource<CitySource>();
                    e.Property(p => p.State).DataSource<StateSource>();
                    e.Property(p => p.Zip).DataSource<PostalCodeSource>();

                    e.Property(p => p.Note).DataSource<LoremIpsumSource>();
                    e.Property(p => p.Password).DataSource<PasswordSource>();

                    // array of values
                    e.Property(p => p.Status).DataSource(new[] { Status.New, Status.Verified });


                    // don't generate
                    e.Property(p => p.Budget).Ignore();

                    // static value
                    e.Property(p => p.IsActive).Value(true);

                    // delegate value
                    e.Property(p => p.Created).Value(v => DateTime.Now);

                    // repeat call
                    e.Property(p => p.Created).Value(v => DateTime.Now);
                })
            );

            generator.Configuration.Mapping.Count.Should().Be(1);

            var classMapping = generator.Configuration.Mapping.First();
            classMapping.Should().NotBeNull();

            classMapping.Value.Members.Count.Should().Be(13);

            var instance = generator.Single<User>();
            instance.Should().NotBeNull();
            instance.FirstName.Should().NotBeNull();
            instance.LastName.Should().NotBeNull();
            instance.Address1.Should().NotBeNull();
            instance.City.Should().NotBeNull();
            instance.State.Should().NotBeNull();
            instance.Zip.Should().NotBeNull();
            instance.Note.Should().NotBeNull();
            instance.Password.Should().NotBeNull();
            instance.EmailAddress.Should().Be($"{instance.FirstName}.{instance.LastName}@mailinator.com");
        }

        [Fact]
        public void GenerateAutoMap()
        {
            var generator = Generator.Create(c => c
                .ExcludeName("xunit")
            );
            var instance = generator.Single<User>();
            instance.Should().NotBeNull();
            instance.FirstName.Should().NotBeNull();
        }

        [Fact]
        public void GenerateFactory()
        {
            var generator = Generator.Create(c => c
                .ExcludeName("xunit")
                .Entity<User>(e =>
                {
                    e.AutoMap();
                    e.Factory(t => new User { FirstName = "Factory" });
                    e.Property(p => p.FirstName).Ignore();
                })
            );

            var instance = generator.Single<User>();
            instance.Should().NotBeNull();
            instance.FirstName.Should().Be("Factory");
            instance.LastName.Should().NotBeNull();
        }


        [Fact]
        public void GenerateProfile()
        {
            var generator = Generator.Create(c => c
                .ExcludeName("xunit")
                .Profile<UserProfile>()
            );


            var instance = generator.Single<User>();
            instance.Should().NotBeNull();
            instance.FirstName.Should().NotBeNull();
        }


        [Fact]
        public void GenerateChildren()
        {
            var generator = Generator.Create(c => c
                .ExcludeName("xunit")
                .Entity<Order>(e =>
                {
                    e.Property(p => p.User).Single<User>();
                    e.Property(p => p.Items).List<OrderLine>(2);
                })

                .Entity<OrderLine>(e =>
                {
                    e.Property(p => p.Quantity).IntegerSource(1, 10);
                })
            );

            var instance = generator.Single<Order>();
            instance.Should().NotBeNull();
            instance.Name.Should().NotBeNull();
            instance.User.Should().NotBeNull();
            instance.Items.Should().NotBeNull();
            instance.Items.Count.Should().Be(2);
        }

        [Fact]
        public void GenerateSingleOverride()
        {
            var generator = Generator.Create(c => c
                .ExcludeName("xunit")
                .Entity<User>(e =>
                {
                    e.AutoMap();

                    e.Property(p => p.FirstName).DataSource<FirstNameSource>();
                    e.Property(p => p.LastName).DataSource<LastNameSource>();
                    e.Property(p => p.Address1).DataSource<StreetSource>();
                    e.Property(p => p.City).DataSource<CitySource>();
                    e.Property(p => p.State).DataSource<StateSource>();
                    e.Property(p => p.Zip).DataSource<PostalCodeSource>();

                    e.Property(p => p.Note).DataSource<LoremIpsumSource>();
                    e.Property(p => p.Password).DataSource<PasswordSource>();
                })
            );

            generator.Configuration.Mapping.Count.Should().Be(1);

            var classMapping = generator.Configuration.Mapping.First();
            classMapping.Should().NotBeNull();

            classMapping.Value.Members.Count.Should().Be(8);

            var instance = generator.Single<User>(e =>
            {
                // override note property with static value
                e.Property(p => p.Note).Value("Test");
            });

            instance.Should().NotBeNull();
            instance.FirstName.Should().NotBeNull();
            instance.LastName.Should().NotBeNull();
            instance.Address1.Should().NotBeNull();
            instance.City.Should().NotBeNull();
            instance.State.Should().NotBeNull();
            instance.Zip.Should().NotBeNull();
            instance.Note.Should().Be("Test");
            instance.Password.Should().NotBeNull();

            // make sure original mapping hasn't changed
            var userMapping = generator.Configuration.Mapping.Values.FirstOrDefault(p => p.TypeAccessor.Type == typeof(User));
            userMapping.Should().NotBeNull();

            var memberMapping = userMapping.Members.FirstOrDefault(m => m.MemberAccessor.Name == "Note");
            memberMapping.Should().NotBeNull();
            memberMapping.DataSource.Should().BeOfType<LoremIpsumSource>();
        }

        [Fact]
        public void GenerateListOverride()
        {
            var generator = Generator.Create(c => c
                .ExcludeName("xunit")
                .Entity<User>(e =>
                {
                    e.AutoMap();

                    e.Property(p => p.FirstName).DataSource<FirstNameSource>();
                    e.Property(p => p.LastName).DataSource<LastNameSource>();
                    e.Property(p => p.Address1).DataSource<StreetSource>();
                    e.Property(p => p.City).DataSource<CitySource>();
                    e.Property(p => p.State).DataSource<StateSource>();
                    e.Property(p => p.Zip).DataSource<PostalCodeSource>();

                    e.Property(p => p.Note).DataSource<LoremIpsumSource>();
                    e.Property(p => p.Password).DataSource<PasswordSource>();
                })
            );

            generator.Configuration.Mapping.Count.Should().Be(1);

            var classMapping = generator.Configuration.Mapping.First();
            classMapping.Should().NotBeNull();

            classMapping.Value.Members.Count.Should().Be(8);

            var list = generator.List<User>(e =>
            {
                e.Count(10);
                // override note property
                e.Property(p => p.Note).Value("Test");
            });

            list.Should().NotBeNullOrEmpty();
            list.Count.Should().Be(10);

            var instance = list.First();
            instance.Should().NotBeNull();
            instance.FirstName.Should().NotBeNull();
            instance.LastName.Should().NotBeNull();
            instance.Address1.Should().NotBeNull();
            instance.City.Should().NotBeNull();
            instance.State.Should().NotBeNull();
            instance.Zip.Should().NotBeNull();
            instance.Note.Should().Be("Test");
            instance.Password.Should().NotBeNull();

            // make sure original mapping hasn't changed
            var userMapping = generator.Configuration.Mapping.Values.FirstOrDefault(p => p.TypeAccessor.Type == typeof(User));
            userMapping.Should().NotBeNull();

            var memberMapping = userMapping.Members.FirstOrDefault(m => m.MemberAccessor.Name == "Note");
            memberMapping.Should().NotBeNull();
            memberMapping.DataSource.Should().BeOfType<LoremIpsumSource>();
        }
    }
}
