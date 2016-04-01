using System;
using System.Security.Cryptography;
using System.Threading;
using DataGenerator.Extensions;

namespace DataGenerator
{
    /// <summary>
    /// A shared thread-safe instance of <see cref="T:System.Random"/>.
    /// </summary>
    public static class RandomGenerator
    {
        // one random generator per thread
        private static readonly RNGCryptoServiceProvider _seed = new RNGCryptoServiceProvider();
        private static readonly ThreadLocal<Random> _local = new ThreadLocal<Random>(() => new Random(_seed.Next()));

        /// <summary>
        /// Gets the thread-safe instance of <see cref="T:System.Random"/>.
        /// </summary>
        /// <value>
        /// The thread-safe instance of <see cref="T:System.Random"/>.
        /// </value>
        public static Random Current => _local.Value;
    }
}