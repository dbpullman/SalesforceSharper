using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Generator
{
    public class ClassGenerator
    {
        public string Name { get; set; }
        public string AccessModifier { get; set; }
        public string Namespace { get; set; }
        public List<Property> Properties { get; set; }
        public List<UsingStatement> UsingStatements { get; set; }

        public ClassGenerator()
        {
            UsingStatements = new List<UsingStatement>();
            Properties = new List<Property>();
        }

        public string Generate()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AddUsingStatements(UsingStatements);
            stringBuilder.AppendLine();
            stringBuilder.AddNamespace(Namespace);
            stringBuilder.AddOpeneningBracket();
            stringBuilder.AppendLine();
            stringBuilder.AddClassModifierAndName(AccessModifier, Name);
            stringBuilder.AddOpeneningBracket();
            stringBuilder.AddProperties(Properties);
            stringBuilder.AddClosingBracket();
            stringBuilder.AddClosingBracket();

            return stringBuilder.ToString();
        }
    }
}
