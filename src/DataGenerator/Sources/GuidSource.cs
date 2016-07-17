using System;

namespace DataGenerator.Sources
{
    /// <summary>
    /// <see cref="Guid"/> value generator data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourcePropertyType" />
    public class GuidSource : DataSourcePropertyType
    {
        private static readonly Type[] _types = { typeof(Guid) };

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidSource"/> class.
        /// </summary>
        public GuidSource() : base(_types)
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
            return Guid.NewGuid();
        }

    }
}