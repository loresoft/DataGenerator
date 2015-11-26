using System;

namespace DataGenerator.Sources
{
    public abstract class DataSourceBase : IDataSourceDiscover
    {
        public const int MatchNamePriority = 0099;
        public const int ContainNamePriority = 0999;
        public const int PropertyTypePriority = 9999;


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