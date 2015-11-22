using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Sources
{
    public class FirstNameSource : DataSourceMatchName
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _names = { "FirstName" };
        private static readonly Type[] _types = { typeof(string) };
        private static readonly string[] _firstNames =
        {
            "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Charles",
            "Thomas", "Christopher", "Daniel", "Matthew", "Donald", "Anthony", "Mark", "Paul", "Steven",
            "George", "Kenneth", "Andrew", "Edward", "Joshua", "Brian", "Kevin", "Ronald", "Timothy", "Jason",
            "Jeffrey", "Ryan", "Gary", "Nicholas", "Eric", "Jacob", "Stephen", "Jonathan", "Larry", "Frank",
            "Scott", "Justin", "Brandon", "Raymond", "Gregory", "Samuel", "Benjamin", "Patrick", "Jack",
            "Dennis", "Alexander", "Jerry", "Mary", "Patricia", "Jennifer", "Elizabeth", "Linda", "Barbara",
            "Susan", "Margaret", "Jessica", "Sarah", "Dorothy", "Karen", "Nancy", "Betty", "Lisa", "Sandra",
            "Ashley", "Kimberly", "Donna", "Helen", "Carol", "Michelle", "Emily", "Amanda", "Melissa", "Deborah",
            "Laura", "Stephanie", "Rebecca", "Sharon", "Cynthia", "Kathleen", "Anna", "Shirley", "Ruth",
            "Amy", "Angela", "Brenda", "Virginia", "Pamela", "Catherine", "Katherine", "Nicole", "Christine",
            "Samantha", "Janet", "Debra", "Carolyn", "Rachel", "Heather"
        };

        public FirstNameSource() : base(_types, _names)
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            return _firstNames[_random.Next(0, _firstNames.Length)];
        }
    }
}
