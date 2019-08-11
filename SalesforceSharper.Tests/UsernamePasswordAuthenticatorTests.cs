using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceSharp.Authentication;
using System.Threading.Tasks;

namespace SalesforceSharp.Tests
{
    [TestClass]
    public class UsernamePasswordAuthenticatorTests
    {
        [TestMethod]
        public async Task AuthenticateShouldReturnValidAuthenticationInfo()
        {
            var auth = new UsernamePasswordAuthenticator("ConsumerKey",
                "ConsumerSecret",
                "Username",
                "Password+SecurityToken");

            var authInfo = await auth.Authenticate();

            Assert.IsNotNull(authInfo);
            Assert.IsNotNull(authInfo.AccessToken);
            Assert.IsNotNull(authInfo.InstanceUrl);
        }
    }
}
