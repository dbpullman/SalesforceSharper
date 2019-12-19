using System.Linq;

namespace SalesforceSharper.Generator
{
    public class SalesforceClassGenerator : ClassGenerator
    {
        public SalesforceClassGenerator(ObjectDescribeResponse describe) : base()
        {
            AccessModifier = "public";
            Namespace = GetType().Namespace;
            Name = describe.Label;
            UsingStatements.Add(new UsingStatement() { Name = "Newtonsoft.Json" });
            
            foreach(var field in describe.Fields.OrderBy(p => p.Name))
            {
                Properties.Add(field.ConvertToProperty());
            }
        }
    }
}
