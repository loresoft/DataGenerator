using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Reflection;

namespace DataGenerator
{
    public class ClassMapping
    {
        public ClassMapping()
        {
            AutoMap = true;
            Members = new List<MemberMapping>();
            SyncRoot = new object();
        }

        public ClassMapping(TypeAccessor typeAccessor) : this()
        {
            TypeAccessor = typeAccessor;
        }

        public bool AutoMap { get; set; }

        public bool Ignored { get; set; }

        public bool Mapped { get; set; }

        public TypeAccessor TypeAccessor { get; set; }

        public List<MemberMapping> Members { get; }

        public object SyncRoot { get; }
    }
}
