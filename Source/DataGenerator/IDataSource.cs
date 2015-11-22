using System;

namespace DataGenerator
{
    public interface IDataSource
    {
        object NextValue(IGenerateContext generateContext);
    }

    public interface IDataSourceDiscover : IDataSource
    {
        int Priority { get; }

        bool TryMap(IMappingContext mappingContext);
    }
}
