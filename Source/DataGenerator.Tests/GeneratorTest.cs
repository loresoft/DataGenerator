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


        [Fact]
        public void GenerateProfile()
        {
            Generator.Configuration.Mapping.Clear();
            Generator.Configure(c => c
                .Profile<UserProfile>()
            );


            var instance = Generator.Single<User>();
            instance.Should().NotBeNull();
            instance.FirstName.Should().NotBeNull();
        }


        [Fact]
        public void GenerateChildren()
        {
            Generator.Configuration.Mapping.Clear();
            Generator.Configure(c => c
                .Entity<Order>(e =>
                {
                    e.Property(p => p.User).Value(Generator.Single<User>);
                    e.Property(p => p.Items).Value(() => Generator.List<OrderLine>(2).ToList());
                })

                .Entity<OrderLine>(e =>
                {
                    e.Property(p => p.Quantity).IntegerSource(1, 10);
                })
            );

            var instance = Generator.Single<Order>();
            instance.Should().NotBeNull();
            instance.Name.Should().NotBeNull();
            instance.User.Should().NotBeNull();
            instance.Items.Should().NotBeNull();
            instance.Items.Count.Should().Be(2);
        }

        [Fact]
        public void GenerateSingleOverride()
        {
            Generator.Configuration.Mapping.Clear();
            Generator.Configure(c => c
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

            Generator.Configuration.Mapping.Count.Should().Be(1);

            var classMapping = Generator.Configuration.Mapping.First();
            classMapping.Should().NotBeNull();

            classMapping.Value.Members.Count.Should().Be(8);

            var instance = Generator.Single<User>(e =>
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
            var userMapping = Generator.Configuration.Mapping.Values.FirstOrDefault(p => p.TypeAccessor.Type == typeof(User));
            userMapping.Should().NotBeNull();

            var memberMapping = userMapping.Members.FirstOrDefault(m => m.MemberAccessor.Name == "Note");
            memberMapping.Should().NotBeNull();
            memberMapping.DataSource.Should().BeOfType<LoremIpsumSource>();
        }

        [Fact]
        public void GenerateListOverride()
        {
            Generator.Configuration.Mapping.Clear();
            Generator.Configure(c => c
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

            Generator.Configuration.Mapping.Count.Should().Be(1);

            var classMapping = Generator.Configuration.Mapping.First();
            classMapping.Should().NotBeNull();

            classMapping.Value.Members.Count.Should().Be(8);

            var list = Generator.List<User>(e =>
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
            var userMapping = Generator.Configuration.Mapping.Values.FirstOrDefault(p => p.TypeAccessor.Type == typeof(User));
            userMapping.Should().NotBeNull();

            var memberMapping = userMapping.Members.FirstOrDefault(m => m.MemberAccessor.Name == "Note");
            memberMapping.Should().NotBeNull();
            memberMapping.DataSource.Should().BeOfType<LoremIpsumSource>();
        }
    }
}
