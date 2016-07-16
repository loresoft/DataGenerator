using System;

namespace DataGenerator.Sources
{
    public class FactoryDataSource<T> : IDataSource
    {
        public FactoryDataSource(Func<T> factory)
        {
            Factory = factory;
        }

        public Func<T> Factory { get; }

        public object NextValue(IGenerateContext generateContext)
        {
            return Factory();
        }
    }
}