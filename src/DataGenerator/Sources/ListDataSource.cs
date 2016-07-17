using System;
using System.Collections.Generic;
using DataGenerator.Extensions;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Generate value from a list data source
    /// </summary>
    /// <typeparam name="T">Type of value in list</typeparam>
    /// <seealso cref="DataGenerator.IDataSource" />
    public class ListDataSource<T> : IDataSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListDataSource{T}"/> class.
        /// </summary>
        /// <param name="items">The items to generate from.</param>
        public ListDataSource(IEnumerable<T> items)
        {
            Items = new List<T>(items);
        }

        /// <summary>
        /// Gets the items to generate from.
        /// </summary>
        /// <value>
        /// The items to generate from.
        /// </value>
        public List<T> Items { get; }

        /// <summary>
        /// Gets or sets the weight selector.
        /// </summary>
        /// <value>
        /// The weight selector.
        /// </value>
        public Func<T, int> WeightSelector { get; set; }


        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public object NextValue(IGenerateContext generateContext)
        {
            if (Items == null || Items.Count == 0)
                return default(T);


            return Items.Random(WeightSelector);
        }
    }
}