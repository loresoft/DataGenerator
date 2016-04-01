using System;

namespace DataGenerator.Sources
{
    public class GenerateListSource<T> : IDataSource
    {
        public GenerateListSource(int count)
        {
            Count = count;
        }

        public int Count { get; }

        public object NextValue(IGenerateContext generateContext)
        {
            return generateContext.Generator.List<T>(Count);
        }
    }
}