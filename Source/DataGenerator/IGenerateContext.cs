using System;

namespace DataGenerator
{
    /// <summary>
    /// An <see langword="interface"/> defining the current generation state
    /// </summary>
    public interface IGenerateContext
    {
        /// <summary>
        /// Gets the type of the class being generated.
        /// </summary>
        /// <value>
        /// The type of the class.
        /// </value>
        Type ClassType { get; }

        /// <summary>
        /// Gets the type of the member.
        /// </summary>
        /// <value>
        /// The type of the member.
        /// </value>
        Type MemberType { get; }

        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        /// <value>
        /// The name of the member.
        /// </value>
        string MemberName { get; }

        /// <summary>
        /// Gets the generation depth.
        /// </summary>
        /// <value>
        /// The generation depth.
        /// </value>
        int Depth { get; }

        /// <summary>
        /// Gets the current generated instance.
        /// </summary>
        /// <value>
        /// The current generated instance.
        /// </value>
        object Instance { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GenerateContext : IGenerateContext
    {
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