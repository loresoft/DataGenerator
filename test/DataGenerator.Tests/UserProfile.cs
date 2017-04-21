using System;
using DataGenerator.Fluent;
using DataGenerator.Sources;
using DataGenerator.Tests.Models;

namespace DataGenerator.Tests
{
    public class UserProfile : MappingProfile<User>
    {
        public override void Configure()
        {
            Property(p => p.FirstName).DataSource<FirstNameSource>();
            Property(p => p.LastName).DataSource<LastNameSource>();
            Property(p => p.Address1).DataSource<StreetSource>();
            Property(p => p.City).DataSource<CitySource>();
            Property(p => p.State).DataSource<StateSource>();
            Property(p => p.Zip).DataSource<PostalCodeSource>();
            Property(p => p.EmailAddress).Value(u => $"{u.FirstName}.{u.LastName}@mailinator.com");
            Property(p => p.Note).DataSource<LoremIpsumSource>();
            Property(p => p.Password).DataSource<PasswordSource>();

            // array of values
            Property(p => p.Status).DataSource(new[] { Status.New, Status.Verified });


            // don't generate
            Property(p => p.Budget).Ignore();

            // static value
            Property(p => p.IsActive).Value(true);

            // delegate value
            Property(p => p.Created).Value(u => DateTime.UtcNow);
        }
    }
}