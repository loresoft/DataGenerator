using System;

namespace DataGenerator.Tests.Models
{
    public class OrderLine
    {
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }


        public decimal UnitAmount { get; set; }

        public decimal Quantity { get; set; }

        public decimal TotalAmount => UnitAmount * Quantity;
    }
}