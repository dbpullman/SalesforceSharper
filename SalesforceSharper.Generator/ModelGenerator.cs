using SalesforceSharper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Generator
{
    public class ModelGenerator
    {
        //private readonly Dictionary<string, string> lookup = new Dictionary<string, string>()
        //{
        //    { "id", "string" },
        //    { "picklist", "string" },
        //    { "boolean", "bool" },
        //    { "string", "string" },
        //    { "reference", "string" },
        //    { "date", "string" },
        //    { "datetime", "string" },
        //    { "textarea", "string" },
        //    { "phone", "string" },
        //    { "address", "string" },
        //    { "email", "string" },
        //    { "multipicklist", "string" },
        //    { "url", "string" },
        //    { "double", "double" },
        //    { "currency", "double" },
        //    { "int", "int" },
        //    { "percent", "double" }
        //};

        //public string Generate(ModelGeneratorDefinition definition)
        //{
        //    var stringBuilder = new StringBuilder();
        //    definition.UsingStatements.ForEach(u => stringBuilder.AddUsingStatement(u));
        //    stringBuilder.AppendLine();
        //    stringBuilder.AppendLine($"public class {definition.DescribeResponse.Label}");
        //    stringBuilder.AppendLine("{");
        //    foreach (var field in definition.DescribeResponse.Fields.OrderBy(f => f.Name))
        //    {
        //        if (!lookup.TryGetValue(field.Type, out string value))
        //        {
        //            Console.WriteLine(field.Type);
        //        }

        //        stringBuilder.AppendLine($"\t[JsonProperty(\"{field.Name}\")]");
        //        stringBuilder.AppendLine($"\tpublic {lookup[field.Type.ToLower()]} {Util.UnderscoreToPascalCase(field.Name)} {{ get; set; }}");
        //        stringBuilder.AppendLine();
        //    }
        //    stringBuilder.Append("}");

        //    return stringBuilder.ToString();
        //}


    }

    public static class FieldExtensions
    {
        private static readonly Dictionary<string, string> lookup = new Dictionary<string, string>()
        {
            { "id", "string" },
            { "picklist", "string" },
            { "boolean", "bool" },
            { "string", "string" },
            { "reference", "string" },
            { "date", "string" },
            { "datetime", "string" },
            { "textarea", "string" },
            { "phone", "string" },
            { "address", "string" },
            { "email", "string" },
            { "multipicklist", "string" },
            { "url", "string" },
            { "double", "double" },
            { "currency", "double" },
            { "int", "int" },
            { "percent", "double" }
        };

        public static Property ConvertToProperty(this Field field)
        {
            return new Property()
            {
                AccessModifier = "public",
                Type = lookup[field.Type.ToLower()],
                Name = Util.UnderscoreToPascalCase(field.Name),
                Attribute = $"[JsonProperty(\"{field.Name}\")]"
            };
        }
    }
}
