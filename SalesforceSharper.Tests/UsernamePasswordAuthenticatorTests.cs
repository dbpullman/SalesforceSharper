using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceSharper.Authentication;
using SalesforceSharper.Serialization;
using System.Threading.Tasks;

namespace SalesforceSharper.Tests
{
    [TestClass]
    public class UsernamePasswordAuthenticatorTests
    {
        private IConfiguration Configuration;

        [TestMethod]
        public async Task AuthenticateShouldReturnValidAuthenticationInfo()
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<UsernamePasswordAuthenticatorTests>();

            Configuration = builder.Build();

            var auth = new UsernamePasswordAuthenticator(Configuration["Salesforce:ConsumerKey"],
                Configuration["Salesforce:ConsumerSecret"],
                Configuration["Salesforce:Username"],
                Configuration["Salesforce:Password"],
                true);

            var authInfo = await auth.Authenticate();

            Assert.IsNotNull(authInfo);
            Assert.IsNotNull(authInfo.AccessToken);
            Assert.IsNotNull(authInfo.InstanceUrl);
        }
    }
}
