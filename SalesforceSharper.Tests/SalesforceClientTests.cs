using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceSharp.Authentication;
using SalesforceSharp;
using System.Threading.Tasks;

namespace SalesforceSharp.Tests
{

    [TestClass]
    public class SalesforceClientTests
    {
        private SalesforceClient client;

        [TestInitialize]
        public async Task Initialize()
        {
            var auth = new UsernamePasswordAuthenticator("<ConsumerKey>",
                "<ConsumerSecret>",
                "<Username>",
                "<Password>");

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
    }
}
