using System;
using System.Collections.Generic;

namespace DataGenerator.Sources
{
    public class CitySource : DataSourceMatchName
    {
        private static readonly string[] _names = { "City" };
        private static readonly Type[] _types = { typeof(string) };
        private static readonly string[] _cities =
        {
            "New York", "Los Angeles", "Chicago", "Houston", "Philadelphia",
            "Phoenix", "San Diego", "San Antonio", "Dallas", "Detroit", "San Jose",
            "Indianapolis", "Jacksonville", "San Francisco", "Columbus", "Austin",
            "Memphis", "Baltimore", "Charlotte", "Fort Worth", "Boston", "Milwaukee",
            "El Paso", "Washington", "Nashville-Davidson", "Seattle", "Denver",
            "Las Vegas", "Portland", "Oklahoma City", "Tucson", "Albuquerque",
            "Atlanta", "Long Beach", "Kansas City", "Fresno", "New Orleans",
            "Cleveland", "Sacramento", "Mesa", "Virginia Beach", "Omaha",
            "Colorado Springs", "Oakland", "Miami", "Tulsa", "Minneapolis",
            "Honolulu", "Arlington", "Wichita", "St. Louis", "Raleigh", "Santa Ana",
            "Cincinnati", "Anaheim", "Tampa", "Toledo", "Pittsburgh", "Aurora",
            "Bakersfield", "Riverside", "Stockton", "Corpus Christi",
            "Lexington-Fayette", "Buffalo", "St. Paul", "Anchorage", "Newark",
            "Plano", "Fort Wayne", "St. Petersburg", "Glendale", "Lincoln",
            "Norfolk", "Jersey City", "Greensboro", "Chandler", "Birmingham",
            "Henderson", "Scottsdale", "North Hempstead", "Madison", "Hialeah",
            "Baton Rouge", "Chesapeake", "Orlando", "Lubbock", "Garland", "Akron",
            "Rochester", "Chula Vista", "Reno", "Laredo", "Durham", "Modesto",
            "Huntington", "Montgomery", "Boise", "Arlington", "San Bernardino"
        };

        public CitySource() : base(_types, _names)
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            return _cities[RandomGenerator.Current.Next(0, _cities.Length)];
        }
    }
}