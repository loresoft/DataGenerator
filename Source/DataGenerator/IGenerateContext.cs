using System;

namespace DataGenerator
{
    public interface IGenerateContext
    {
        Type ClassType { get; }

        Type MemberType { get; }

        string MemberName { get; }

        int Depth { get; }

        object Instance { get; }
    }

    public class GenerateContext : IGenerateContext
    {
        public Type ClassType { get; set; }

        public Type MemberType { get; set; }

        public string MemberName { get; set; }

        public int Depth { get; set; }

        public object Instance { get; set; }
    }
}