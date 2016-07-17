using System;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Identifier value generator data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
    public class IdentifierSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Id" };
        private static readonly Type[] _types = { typeof(string) };


        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifierSource"/> class.
        /// </summary>
        public IdentifierSource() : base(_types, _names)
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
            return Guid.NewGuid().ToString();
        }

    }
}