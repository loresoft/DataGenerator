using System;
using System.Collections.Generic;
using DataGenerator.Extensions;

namespace DataGenerator.Sources
{
    public class ListDataSource<T> : IDataSource
    {
        public ListDataSource(IEnumerable<T> items)
        {
            Items = new List<T>(items);
        }

        public List<T> Items { get; }

        public Func<T, int> WeightSelector { get; set; }

        public int Priority { get; } = int.MaxValue;

        public bool TryMap(IMappingContext mappingContext)
        {
            return false;
        }

        public object NextValue(IGenerateContext generateContext)
        {
            if (Items == null || Items.Count == 0)
                return default(T);


            return Items.Random(WeightSelector);
        }
    }
}