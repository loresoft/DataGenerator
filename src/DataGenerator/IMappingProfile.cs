using System;

namespace DataGenerator
{
    /// <summary>
    /// An <see langword="interface"/> for mapping a class.
    /// </summary>
    public interface IMappingProfile
    {
        /// <summary>
        /// Gets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        Type EntityType { get; }

        /// <summary>
        /// Registers the specified class mapping.
        /// </summary>
        /// <param name="classMapping">The class mapping.</param>
        void Register(ClassMapping classMapping);
    }
}