using SalesforceSharper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Generator
{
    public class ModelGenerator : IModelGenerator
    {
        private readonly Dictionary<string, string> lookup = new Dictionary<string, string>()
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

        public string Generate(ObjectDescribeResponse describeResponse)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("using Newtonsoft.Json;");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"public class {describeResponse.Label}");
            stringBuilder.AppendLine("{");
            foreach (var field in describeResponse.Fields.OrderBy(f => f.Name))
            {
                if (!lookup.TryGetValue(field.Type, out string value))
                {
                    Console.WriteLine(field.Type);
                }

                stringBuilder.AppendLine($"\t[JsonProperty(\"{field.Name}\")]");
                stringBuilder.AppendLine($"\tpublic {lookup[field.Type.ToLower()]} {Util.UnderscoreToPascalCase(field.Name)} {{ get; set; }}");
                stringBuilder.AppendLine();
            }
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }
    }
}
