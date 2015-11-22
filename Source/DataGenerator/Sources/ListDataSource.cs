using System;
using System.Collections.Generic;

namespace DataGenerator.Sources
{
    public class ListDataSource<T> : IDataSource
    {
        private static readonly Random _random = new Random();

        public ListDataSource(IEnumerable<T> items)
        {
            Items = new List<T>(items);
        }

        public List<T> Items { get; }

        public int Priority { get; } = int.MaxValue;

        public bool TryMap(IMappingContext mappingContext)
        {
            return false;
        }

        public object NextValue(IGenerateContext generateContext)
        {
            if (Items == null || Items.Count == 0)
                return default(T);

            var index = _random.Next(Items.Count - 1);
            return Items[index];
        }
    }
}