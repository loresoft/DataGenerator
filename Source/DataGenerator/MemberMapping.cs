using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Reflection;

namespace DataGenerator
{
    public class MemberMapping
    {
        public bool Ignored { get; set; }

        public IMemberAccessor MemberAccessor { get; set; }

        public IDataSource DataSource { get; set; }
    }
}
