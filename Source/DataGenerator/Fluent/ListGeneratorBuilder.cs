using System;

namespace DataGenerator.Fluent
{
    /// <summary>
    /// A fluent builder for list entity generation.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class ListGeneratorBuilder<TEntity> : ClassMappingBuilder<TEntity>
    {
        private readonly Random _random;


        /// <summary>
        /// Initializes a new instance of the <see cref="ListGeneratorBuilder{TEntity}"/> class.
        /// </summary>
        /// <param name="classMapping">The class mapping.</param>
        public ListGeneratorBuilder(ClassMapping classMapping) : base(classMapping)
        {
            _random = new Random();
            Random(2, 10);
        }

        /// <summary>
        /// Gets or sets the generate count.
        /// </summary>
        /// <value>
        /// The generate count.
        /// </value>
        public int GenerateCount { get; set; }

        /// <summary>
        /// Set the number entities to generate.
        /// </summary>
        /// <param name="count">The number of entities to generate..</param>
        /// <returns>A fluent builder for class mapping.</returns>
        public ListGeneratorBuilder<TEntity> Count(int count)
        {
            GenerateCount = count;
            return this;
        }

        /// <summary>
        /// Set the <paramref name="min" /> and <paramref name="max" /> range for a random number of entities to generate.
        /// </summary>
        /// <param name="min">The minimum value in the random range.</param>
        /// <param name="max">The maximum value in the random range.</param>
        /// <returns>
        /// A fluent builder for class mapping.
        /// </returns>
        public ListGeneratorBuilder<TEntity> Random(int min, int max)
        {
            var count = _random.Next(min, max);
            GenerateCount = count;
            return this;
        }

        /// <summary>
        /// Sets a value indicating whether to automatic map properties of the class.
        /// </summary>
        /// <param name="value"><c>true</c> to automatic map properties; otherwise, <c>false</c>.</param>
        /// <returns>A fluent builder for class mapping.</returns>
        public new ListGeneratorBuilder<TEntity> AutoMap(bool value = true)
        {
            base.AutoMap(value);
            return this;
        }

    }
}