using System;

namespace DataGenerator.Sources
{
    public class StateSource : DataSourceMatchName
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _names = { "State", "StateProvidence" };
        private static readonly Type[] _types = { typeof(string) };
        private static readonly string[] _states =
        {
            "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FM", "FL",
            "GA", "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MH",
            "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM",
            "NY", "NC", "ND", "MP", "OH", "OK", "OR", "PW", "PA", "PR", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VI", "VA", "WA", "WV", "WI", "WY"
        };

        public StateSource() : base(_types, _names)
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            return _states[_random.Next(0, _states.Length)];
        }
    }
}