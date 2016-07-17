using System;

namespace DataGenerator.Sources
{

    /// <summary>
    /// State data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
    public class StateSource : DataSourceMatchName
    {
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

        /// <summary>
        /// Initializes a new instance of the <see cref="StateSource"/> class.
        /// </summary>
        public StateSource() : base(_types, _names)
        {
        }

        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public override object NextValue(IGenerateContext generateContext)
        {
            return _states[RandomGenerator.Current.Next(0, _states.Length)];
        }
    }
}