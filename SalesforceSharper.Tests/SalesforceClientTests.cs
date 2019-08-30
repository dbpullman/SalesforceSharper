using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceSharper.Authentication;
using SalesforceSharper;
using System.Threading.Tasks;
using SalesforceSharper.Serialization;
using Microsoft.Extensions.Configuration;
using System;

namespace SalesforceSharper.Tests
{

    [TestClass]
    public class SalesforceClientTests
    {
        private static SalesforceClient client;
        private static IConfiguration Configuration;
        private static Guid guid;

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

            guid = Guid.NewGuid();
        }

        [TestMethod]
        public async Task QueryShouldReturnOnlyTwoThousandRecords()
        {
            var results = await client.Query<Account>("SELECT Id, Name FROM Account");

            Assert.AreEqual(2000, results.Count);
        }

        [TestMethod]
        public async Task QueryAllShouldReturnMoreThanTwoThousandRecords()
        {
            var result = await client.QueryAll<Account>("SELECT Id, Name FROM Account LIMIT 4000");

            Assert.AreEqual(4000, result.Count);
        }

        [TestMethod]
        public async Task GetByIdShouldReturnObjectWithProvidedId()
        {
            var results = await client.GetById<Account>("0010b00002PvblhAAB");

            Assert.AreEqual("0010b00002PvblhAAB", results.Id);
        }

        [TestMethod]
        public async Task CreateUpdateDeleteShouldExecuteWithoutException()
        {
            var account = new Account()
            {
                Name = "Test Account " + guid.ToString()
            };

            var id = await client.Create(account);

            Assert.IsNotNull(id);

            account.Name = account.Name + "NEW";

            var successfull = await client.Update(id, account);

            Assert.AreEqual(true, successfull);

            successfull = await client.Delete("Account", id);

            Assert.AreEqual(true, successfull);

        }

        [TestMethod]
        public async Task DescribeObjectShouldReturnObjectDescribeResponse()
        {
            var accountDescription = await client.DescribeObject("Account");

            Assert.IsInstanceOfType(accountDescription, typeof(ObjectDescribeResponse));
        }

        [TestMethod]
        public async Task DescribeObjectShouldReturnObjectDescribeResponseWithNameValue()
        {
            var accountDescription = await client.DescribeObject("Account");

            Assert.IsNotNull(accountDescription.Name);
        }

        [TestMethod]
        public async Task DescribeObjectShouldReturnObjectDescribeResponseWithFields()
        {
            var accountDescription = await client.DescribeObject("Account");

            Assert.AreEqual(true, accountDescription.Fields.Count > 0);
        }
    }
}
