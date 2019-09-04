using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Generator
{
    public static class StringBuilderExtensions
    {
        public static void AddUsingStatement(this StringBuilder builder, string library)
        {
            builder.AppendLine($"using { library.TrimEnd(';') + ";" }");
        }
    }

    public abstract class ClassGenerator : IClassGenerator
    {
        public ClassGenerator(string name, string nameSpace, List<string> usingStatements, List<string> properties)
        {
            Name = name;
            Namespace = nameSpace;
            UsingStatements = usingStatements;
            Properties = properties;
        }

        public ClassGenerator(string name) : this(name, "ModelGenerator", new List<string>(), new List<string>()) { }

        public string Namespace { get; set; }
        public List<string> UsingStatements { get; set; }
        public List<string> Properties { get; set; }
        public string Name { get; set; }

        protected virtual string Generate(StringBuilder builder)
        {
            UsingStatements.ForEach(u => builder.AddUsingStatement(u));
            builder.AppendLine();
            builder.AppendLine($"namespace {Namespace}");
            builder.AppendLine("{");
            builder.AppendLine($"\tpublic class {Name}");
            builder.AppendLine("\t{");
            Properties.ForEach(p => builder.AppendLine($"\t\t{p}"));
            builder.AppendLine("\t}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        public string Generate()
        {
            return Generate(new StringBuilder());
        }
    }
}
