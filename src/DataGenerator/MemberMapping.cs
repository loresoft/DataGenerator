using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Reflection;

namespace DataGenerator
{
    /// <summary>
    /// Mapping information for a class member.
    /// </summary>
    public class MemberMapping
    {
        /// <summary>
        /// Gets or sets a value indicating whether the member is ignored.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ignored; otherwise, <c>false</c>.
        /// </value>
        public bool Ignored { get; set; }

        /// <summary>
        /// Gets or sets the member accessor.
        /// </summary>
        /// <value>
        /// The member accessor.
        /// </value>
        public IMemberAccessor MemberAccessor { get; set; }

        /// <summary>
        /// Gets or sets the data source used for generating values.
        /// </summary>
        /// <value>
        /// The data source used for generating values.
        /// </value>
        public IDataSource DataSource { get; set; }
    }
}
