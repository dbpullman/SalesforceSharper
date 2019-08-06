using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SalesforceSharp.Authentication
{
    public class UsernamePasswordAuthenticator : IAuthenticator
    {
        private readonly string consumerKey;
        private readonly string consumerSecret;
        private readonly string username;
        private readonly string password;

        public UsernamePasswordAuthenticator(string consumerKey, string consumerSecret, string username, string password)
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.username = username;
            this.password = password;
        }

        public async Task<AuthenticationInfo> Authenticate()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://login.salesforce.com/");
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("client_id", consumerKey),
                new KeyValuePair<string, string>("client_secret", consumerSecret),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            var response = await client.PostAsync("services/oauth2/token", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AuthenticationInfo>(responseContent, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });
        }
    }
}
