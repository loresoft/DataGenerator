using System;

namespace DataGenerator
{
    /// <summary>
    /// Data generation context state
    /// </summary>
    public class GenerateContext : IGenerateContext
    {
        /// <summary>
        /// Gets or sets the current generator.
        /// </summary>
        /// <value>
        /// The current generator.
        /// </value>
        public Generator Generator { get; set; }

        /// <summary>
        /// Gets the type of the class being generated.
        /// </summary>
        /// <value>
        /// The type of the class.
        /// </value>
        public Type ClassType { get; set; }

        /// <summary>
        /// Gets the type of the member.
        /// </summary>
        /// <value>
        /// The type of the member.
        /// </value>
        public Type MemberType { get; set; }

        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        /// <value>
        /// The name of the member.
        /// </value>
        public string MemberName { get; set; }

        /// <summary>
        /// Gets the generation depth.
        /// </summary>
        /// <value>
        /// The generation depth.
        /// </value>
        public int Depth { get; set; }

        /// <summary>
        /// Gets the current generated instance.
        /// </summary>
        /// <value>
        /// The current generated instance.
        /// </value>
        public object Instance { get; set; }

    }
}