using SalesforceSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace SalesforceSharp.Authentication
{
    public class UsernamePasswordAuthenticator : IAuthenticator
    {
        private readonly string consumerKey;
        private readonly string consumerSecret;
        private readonly string username;
        private readonly string password;
        private readonly ISerializer serializer;

        public UsernamePasswordAuthenticator(string consumerKey, string consumerSecret, string username, string password) : this(consumerKey, consumerSecret, username, password, new JsonSerializer())
        { }

        public UsernamePasswordAuthenticator(string consumerKey, string consumerSecret, string username, string password, ISerializer serializer)
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.username = username;
            this.password = password;
            this.serializer = serializer;
        }

        public async Task<AuthenticationInfo> Authenticate()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://login.salesforce.com/");
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
