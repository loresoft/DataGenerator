using System;

namespace DataGenerator
{
    /// <summary>
    /// Class mapping context
    /// </summary>
    public class MappingContext : IMappingContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingContext"/> class.
        /// </summary>
        /// <param name="classMapping">The class mapping.</param>
        /// <param name="memberMapping">The member mapping.</param>
        public MappingContext(ClassMapping classMapping, MemberMapping memberMapping)
        {
            ClassMapping = classMapping;
            MemberMapping = memberMapping;
        }

        /// <summary>
        /// Gets the current class mapping.
        /// </summary>
        /// <value>
        /// The current class mapping.
        /// </value>
        public ClassMapping ClassMapping { get; }

        /// <summary>
        /// Gets the member mapping.
        /// </summary>
        /// <value>
        /// The member mapping.
        /// </value>
        public MemberMapping MemberMapping { get; }

    }
}