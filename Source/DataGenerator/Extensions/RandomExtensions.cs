using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Extensions
{
    public static class RandomExtensions
    {
        private static readonly Random _random = new Random();

        public static T Random<T>(this IList<T> list)
        {
            if (list == null || list.Count < 1)
                return default(T);

            var index = _random.Next(list.Count - 1);
            return list[index];
        }

        public static IEnumerable<T> Random<T>(this IList<T> list, int count)
        {
            if (list == null || list.Count < 1 || count < 1)
                yield break;

            for (int i = 0; i < count; i++)
                yield return Random(list);
        }

        public static T Random<T>(this IList<T> list, Func<T, int> weightSelector)
        {
            if (list == null || list.Count < 1)
                return default(T);

            int totalWeight = 0;
            var selected = default(T);

            foreach (var data in list)
            {
                int weight = weightSelector(data);
                int r = _random.Next(totalWeight + weight);

                if (r >= totalWeight)
                    selected = data;

                totalWeight += weight;
            }

            return selected;
        }

        public static IEnumerable<T> Random<T>(this IList<T> list, Func<T, int> weightSelector, int count)
        {
            if (list == null || list.Count < 1 || count < 1)
                yield break;

            for (int i = 0; i < count; i++)
                yield return Random(list, weightSelector);
        }
    }
}
