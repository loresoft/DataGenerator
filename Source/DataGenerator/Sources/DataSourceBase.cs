using System;

namespace DataGenerator.Sources
{
    public abstract class DataSourceBase : IDataSourceDiscover
    {
        public const int MatchNamePriority = 0010;
        public const int ContainNamePriority = 0100;
        public const int PropertyTypePriority = 1000;


        protected DataSourceBase() : this(int.MaxValue)
        {
        }

        protected DataSourceBase(int priority)
        {
            Priority = priority;
        }

        public int Priority { get; }


        public abstract bool TryMap(IMappingContext mappingContext);

        public abstract object NextValue(IGenerateContext generateContext);
    }
}