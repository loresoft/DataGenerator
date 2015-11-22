using System;

namespace DataGenerator.Tests.Models
{
    public enum Status
    {
        New,
        Verified
    }

    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string Note { get; set; }
        public decimal Budget { get; set; }

        public string Password { get; set; }

        public Status Status { get; set; }

        public bool IsActive { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}