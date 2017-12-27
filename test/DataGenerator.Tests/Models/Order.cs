using System;
using System.Collections.Generic;

namespace DataGenerator.Tests.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Total { get; set; }

        public DateTimeOffset Ordered { get; set; }

        public User User { get; set; }

        public List<OrderLine> Items { get; set; }
    }
}