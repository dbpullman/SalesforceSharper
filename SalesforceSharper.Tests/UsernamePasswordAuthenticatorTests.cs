using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceSharper.Authentication;
using SalesforceSharper.Serialization;
using System.Threading.Tasks;

namespace SalesforceSharper.Tests
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
