using System;

namespace DataGenerator.Sources
{
    public class GenerateSingleSource<T> : IDataSource
    {
        public object NextValue(IGenerateContext generateContext)
        {
            return generateContext.Generator.Single<T>();
        }
    }
}