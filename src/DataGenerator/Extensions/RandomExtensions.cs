using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Extensions
{
    /// <summary>
    /// Extension methods for randomization
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Gets a random value from the specified <paramref name="list"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to get a random value from.</param>
        /// <returns>A random value from the list.</returns>
        public static T Random<T>(this IList<T> list)
        {
            if (list == null || list.Count < 1)
                return default(T);

            var index = RandomGenerator.Current.Next(list.Count - 1);
            return list[index];
        }

        /// <summary>
        /// Gets random values from the specified <paramref name="list" />.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to get a random value from.</param>
        /// <param name="count">The number of random items to return.</param>
        /// <returns>
        /// Random values from the list.
        /// </returns>
        public static IEnumerable<T> Random<T>(this IList<T> list, int count)
        {
            if (list == null || list.Count < 1 || count < 1)
                yield break;

            for (int i = 0; i < count; i++)
                yield return Random(list);
        }

        /// <summary>
        /// Gets a random value from the specified <paramref name="list" /> using the <paramref name="weightSelector" /> to weight the values.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to get a random value from.</param>
        /// <param name="weightSelector">The value weight selector.</param>
        /// <returns>
        /// A random value from the list.
        /// </returns>
        public static T Random<T>(this IList<T> list, Func<T, int> weightSelector)
        {
            if (list == null || list.Count < 1)
                return default(T);

            if (weightSelector == null)
                return list.Random();

            int totalWeight = 0;
            var selected = default(T);

            foreach (var data in list)
            {
                int weight = weightSelector(data);
                int r = RandomGenerator.Current.Next(totalWeight + weight);

                if (r >= totalWeight)
                    selected = data;

                totalWeight += weight;
            }

            return selected;
        }

        /// <summary>
        /// Gets random values from the specified <paramref name="list" /> using the <paramref name="weightSelector" /> to weight the values.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to get a random value from.</param>
        /// <param name="weightSelector">The value weight selector.</param>
        /// <param name="count">The number of random items to return.</param>
        /// <returns>
        /// Random values from the list.
        /// </returns>
        public static IEnumerable<T> Random<T>(this IList<T> list, Func<T, int> weightSelector, int count)
        {
            if (list == null || list.Count < 1 || count < 1)
                yield break;

            for (int i = 0; i < count; i++)
                yield return Random(list, weightSelector);
        }


        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <param name="generator">The generator.</param>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0 and less than MaxValue.</returns>
        public static int Next(this RandomNumberGenerator generator)
        {
            var buffer = new byte[4];
            generator.GetBytes(buffer);

            return BitConverter.ToInt32(buffer, 0);
        }

    }
}
