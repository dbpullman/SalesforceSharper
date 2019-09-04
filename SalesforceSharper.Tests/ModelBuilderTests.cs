using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceSharper.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesforceSharper.Generator;
using SalesforceSharper.Authentication;
using Microsoft.Extensions.Configuration;

namespace SalesforceSharper.Tests
{
    [TestClass]
    public class ModelBuilderTests
    {
        [TestMethod]
        public void BuildShouldGenerateStringFromDescribe()
        {
            var describe = new ObjectDescribeResponse()
            {
                Label = "CustomObject",
                Name = "Custom_Object__c",
                Fields = new List<Field>()
                {
                    new Field() { Name = "Id", Type = "id" },
                    new Field() { Name = "Name", Type = "string" },
                    new Field() { Name = "Custom_Field__c", Type = "string" }
                }
            };

            var builder = new ModelGenerator();
            var classString = builder.Generate(describe);

            Assert.IsNotNull(classString);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            var properties = new List<Field>()
            {
                new Field() { Name = "Id", Type = "id" },
                new Field() { Name = "Name", Type = "string" },
                new Field() { Name = "Custom_Field__c", Type = "string" }
            };

            var generator = new TestClassGenerator("Account")
            {
                Namespace = "SalesforceSharper.Tests",
                Properties = properties.Select(i => $"public {i.Type} {i.Name} {{ get; set; }}").ToList(),
                UsingStatements = new List<string>()
                {
                    "Newtonsoft.Json;",
                    "SalesforceSharper.Interfaces"
                }
            };

            var classString = generator.Generate();
        }
    }

    public class TestClassGenerator : ClassGenerator
    {
        public TestClassGenerator(string name) : base(name)
        {
            Namespace = "SalesforceSharper.Tests";
            UsingStatements = new List<string>()
            {
                "using Newtonsoft.Json;",
                "using SalesforceSharper;"
            };
        }

        protected override string Generate(StringBuilder builder)
        {
            return base.Generate(builder);
        }
    }
}
