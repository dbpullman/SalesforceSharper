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
        private static SalesforceClient client;
        private static IConfiguration Configuration;

        [ClassInitialize]
        public static async Task Initialize(TestContext context)
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<SalesforceClientTests>();

            Configuration = builder.Build();

            var auth = new UsernamePasswordAuthenticator(Configuration["Salesforce:ConsumerKey"],
                Configuration["Salesforce:ConsumerSecret"],
                Configuration["Salesforce:Username"],
                Configuration["Salesforce:Password"],
                true);

            var authInfo = await auth.Authenticate();

            client = new SalesforceClient(authInfo.InstanceUrl, authInfo.AccessToken);
        }

        [TestMethod]
        public void ClassGeneratorTests()
        {
            var generator = new ClassGenerator()
            {
                Namespace = "SalesforceSharper.Tests",
                Name = "Account",
                AccessModifier = "public",
                UsingStatements = new List<UsingStatement>()
                {
                    new UsingStatement() { Name = "Newtonsoft.Json" }
                },
                Properties = new List<Property>()
                {
                    new Property()
                    {
                        AccessModifier = "public",
                        Name = "Id",
                        Type = "string",
                        Attribute = "[JsonProperty(\"Id\")]"
                    },
                    new Property()
                    {
                        AccessModifier = "public",
                        Name = "NumberOfEmployees",
                        Type = "int",
                        Attribute = "[JsonProperty(\"NumberOfEmployees\")]"
                    }
                }
            };

            var definition = generator.Generate();
        }

        [TestMethod]
        public void ClassGeneratorTest2()
        {
            var describe = new ObjectDescribeResponse()
            {
                Label = "CustomObject",
                Name = "Custom_Object__c",
                Fields = new List<Field>()
                {
                    new Field() { Name = "Id", Type = "id" },
                    new Field() { Name = "Name", Type = "string" },
                    new Field() { Name = "Custom_Field__c", Type = "string" },
                    new Field() { Name = "Custom_Field_Again__c", Type = "int"}
                }
            };

            var generator = new SalesforceClassGenerator(describe);

            var classDefinition = generator.Generate();
        }

        [TestMethod]
        public async Task Generate_ShouldGenerateStringFromObjectDescribe()
        {
            var describe = await client.DescribeObject("Account");
            var generator = new SalesforceClassGenerator(describe);
            var classDefinition = generator.Generate();

            Assert.IsNotNull(describe);
            Assert.AreEqual("Account", generator.Name);
        }
    }
}
