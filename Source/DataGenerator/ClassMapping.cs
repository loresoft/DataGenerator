using System;
using System.Collections.Generic;
using DataGenerator.Reflection;

namespace DataGenerator
{
    /// <summary>
    /// Mapping information on how to generate a class
    /// </summary>
    public class ClassMapping : ICloneable
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
        /// Gets or sets the instance creation factory.
        /// </summary>
        /// <value>
        /// The instance creation factory.
        /// </value>
        public Func<Type, object> Factory { get; set; }

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


        /// <summary>
        /// Creates a new <see langword="object"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Creates a new <see langword="object"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public ClassMapping Clone()
        {
            var classMapping = new ClassMapping
            {
                AutoMap = AutoMap,
                Ignored = Ignored,
                Mapped = Mapped,
                TypeAccessor = TypeAccessor,

            };


            foreach (var m in Members)
            {
                var memberMapping = new MemberMapping
                {
                    Ignored = m.Ignored,
                    MemberAccessor = m.MemberAccessor,
                    DataSource = m.DataSource
                };

                classMapping.Members.Add(memberMapping);
            }

            return classMapping;
        }
    }
}
