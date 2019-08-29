using SalesforceSharper.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace SalesforceSharper.Authentication
{
    public class UsernamePasswordAuthenticator : IAuthenticator
    {
        private readonly string consumerKey;
        private readonly string consumerSecret;
        private readonly string username;
        private readonly string password;
        private readonly bool isSandbox;
        private readonly ISerializer serializer;

        public UsernamePasswordAuthenticator(string consumerKey, string consumerSecret, string username, string password) : this(consumerKey, consumerSecret, username, password, false, new JsonSerializer())
        { }

        public UsernamePasswordAuthenticator(string consumerKey, string consumerSecret, string username, string password, bool isSandbox) : this(consumerKey, consumerSecret, username, password, isSandbox, new JsonSerializer())
        { }

        public UsernamePasswordAuthenticator(string consumerKey, string consumerSecret, string username, string password, bool isSandbox, ISerializer serializer)
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.username = username;
            this.password = password;
            this.isSandbox = isSandbox;
            this.serializer = serializer;
        }

        public async Task<AuthenticationInfo> Authenticate()
        {
            using (var client = new HttpClient())
            {
                var baseAddress = isSandbox ? "https://login.salesforce.com" : "https://test.salesforce.com";
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(serializer.ContentType));
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

                return serializer.Deserialize<AuthenticationInfo>(responseContent);
            }

            //return JsonConvert.DeserializeObject<AuthenticationInfo>(responseContent, new JsonSerializerSettings()
            //{
            //    ContractResolver = new DefaultContractResolver()
            //    {
            //        NamingStrategy = new SnakeCaseNamingStrategy()
            //    }
            //});
        }
    }
}
