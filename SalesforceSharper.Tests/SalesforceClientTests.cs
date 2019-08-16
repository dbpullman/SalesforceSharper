using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceSharper.Authentication;
using SalesforceSharper;
using System.Threading.Tasks;
using SalesforceSharper.Serialization;

namespace SalesforceSharper.Tests
{

    [TestClass]
    public class SalesforceClientTests
    {
        private SalesforceClient client;

        [TestInitialize]
        public async Task Initialize()
        {
            var auth = new UsernamePasswordAuthenticator("ConsumerKey",
                "ConsumerSecret",
                "Username",
                "Password+SecurityToken");

            var authInfo = await auth.Authenticate();

            client = new SalesforceClient(authInfo.InstanceUrl, authInfo.AccessToken);
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
    }
}
