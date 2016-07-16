using System;

namespace DataGenerator
{
    /// <summary>
    /// An <see langword="interface"/> for discoverint data sources
    /// </summary>
    public interface IDataSourceDiscover : IDataSource
    {
        /// <summary>
        /// Gets the priority of the data source.
        /// </summary>
        /// <value>
        /// The priority of the data source.
        /// </value>
        int Priority { get; }

        /// <summary>
        /// Test if the current <paramref name="mappingContext"/> can use this data source.
        /// </summary>
        /// <param name="mappingContext">The mapping context.</param>
        /// <returns><c>true</c> if this data source can be used; otherwise <c>false</c>.</returns>
        bool TryMap(IMappingContext mappingContext);
    }
}