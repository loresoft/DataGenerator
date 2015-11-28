using System;
using System.Collections.Generic;
using DataGenerator.Reflection;

namespace DataGenerator
{
    /// <summary>
    /// Mapping information on how to generate a class
    /// </summary>
    public class ClassMapping
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassMapping"/> class.
        /// </summary>
        public ClassMapping()
        {
            AutoMap = true;
            Members = new List<MemberMapping>();
            SyncRoot = new object();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassMapping"/> class.
        /// </summary>
        /// <param name="typeAccessor">The type accessor.</param>
        public ClassMapping(TypeAccessor typeAccessor) : this()
        {
            TypeAccessor = typeAccessor;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to automatic map properties of the class.
        /// </summary>
        /// <value>
        ///   <c>true</c> to automatic map properties; otherwise, <c>false</c>.
        /// </value>
        public bool AutoMap { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the class is ignored.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ignored; otherwise, <c>false</c>.
        /// </value>
        public bool Ignored { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="AutoMap"/> has completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if AutoMap completed; otherwise, <c>false</c>.
        /// </value>
        public bool Mapped { get; set; }

        /// <summary>
        /// Gets or sets the type accessor.
        /// </summary>
        /// <value>
        /// The type accessor.
        /// </value>
        public TypeAccessor TypeAccessor { get; set; }

        /// <summary>
        /// Gets the class mapped members.
        /// </summary>
        /// <value>
        /// The class mapped members.
        /// </value>
        public List<MemberMapping> Members { get; }

        /// <summary>
        /// Gets the synchronize <see langword="lock"/> object.
        /// </summary>
        /// <value>
        /// The synchronize object.
        /// </value>
        public object SyncRoot { get; }
    }
}
