using System;

namespace DataGenerator
{
    /// <summary>
    /// An <see langword="interface"/> defining the current mapping context.
    /// </summary>
    public interface IMappingContext
    {
        /// <summary>
        /// Gets the current class mapping.
        /// </summary>
        /// <value>
        /// The current class mapping.
        /// </value>
        ClassMapping ClassMapping { get; }

        /// <summary>
        /// Gets the member mapping.
        /// </summary>
        /// <value>
        /// The member mapping.
        /// </value>
        MemberMapping MemberMapping { get; }
    }
}