using System;

namespace DataGenerator.Sources
{
    /// <summary>
    /// A base class for data sources.
    /// </summary>
    /// <seealso cref="DataGenerator.IDataSourceDiscover" />
    public abstract class DataSourceBase : IDataSourceDiscover
    {
        /// <summary>
        /// The match name priority
        /// </summary>
        public const int MatchNamePriority = 0099;
        /// <summary>
        /// The contain name priority
        /// </summary>
        public const int ContainNamePriority = 0999;
        /// <summary>
        /// The property type priority
        /// </summary>
        public const int PropertyTypePriority = 9999;


        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceBase"/> class.
        /// </summary>
        protected DataSourceBase() : this(int.MaxValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceBase"/> class.
        /// </summary>
        /// <param name="priority">The priority of the data source.</param>
        protected DataSourceBase(int priority)
        {
            Priority = priority;
        }

        /// <summary>
        /// Gets the priority of the data source.
        /// </summary>
        /// <value>
        /// The priority of the data source.
        /// </value>
        public int Priority { get; }


        /// <summary>
        /// Test if the current <paramref name="mappingContext" /> can use this data source.
        /// </summary>
        /// <param name="mappingContext">The mapping context.</param>
        /// <returns>
        ///   <c>true</c> if this data source can be used; otherwise <c>false</c>.
        /// </returns>
        public abstract bool TryMap(IMappingContext mappingContext);

        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public abstract object NextValue(IGenerateContext generateContext);
    }
}