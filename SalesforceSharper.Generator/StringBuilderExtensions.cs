using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Generator
{
    public static class StringBuilderExtensions
    {
        private static int openingBracketPosition = 0;
        private static int closingBracketPosition = 0;

        public static void AddUsingStatement(this StringBuilder builder, UsingStatement usingStatement)
        {
            builder.AppendLine($"using { usingStatement.Name?.TrimEnd(';') + ";" }");
        }

        public static void AddUsingStatements(this StringBuilder builder, List<UsingStatement> usingStatements)
        {
            foreach (var us in usingStatements)
            {
                builder.AddUsingStatement(us);
            }
        }

        public static void AddProperty(this StringBuilder builder, Property property)
        {
            builder.Append('\t', openingBracketPosition);
            builder.AppendLine(property.Attribute);
            builder.Append('\t', openingBracketPosition);
            builder.AppendLine($"{property.AccessModifier} {property.Type} {property.Name} {{ get; set; }}");
            builder.AppendLine();
        }

        public static void AddProperties(this StringBuilder builder, List<Property> properties)
        {
            foreach(var property in properties)
            {
                builder.AddProperty(property);
            }

        }

        public static void AddNamespace(this StringBuilder builder, string classNamespace)
        {
            builder.AppendLine($"namespace {classNamespace}");
        }

        public static void AddOpeneningBracket(this StringBuilder builder)
        {
            builder.Append('\t', openingBracketPosition);
            builder.AppendLine("{");
            openingBracketPosition += 1;
            closingBracketPosition = (openingBracketPosition - 1);
        }

        public static void AddClosingBracket(this StringBuilder builder)
        {
            builder.Append('\t', closingBracketPosition);
            builder.AppendLine("}");
            closingBracketPosition -= 1;
            openingBracketPosition = (closingBracketPosition + 1);
        }

        public static void AddClassModifierAndName(this StringBuilder builder, string accessModifier, string name)
        {
            builder.AppendLine($"\t{accessModifier ?? "public"} class {name}");
        }
    }
}
