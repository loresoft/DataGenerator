using System;

namespace DataGenerator.Tests.Models
{
    public class Employee : User
    {
        public string EmployeeNumber { get; set; }
        public DateTime? HireDate { get; set; }
    }
}