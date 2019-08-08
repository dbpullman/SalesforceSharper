using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Net.Http.Headers;

namespace SalesforceSharp.Handlers
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        public readonly string accessToken;

        public AuthenticationHeaderHandler(string accessToken) : base(new ContentTypeHandler())
        {
            this.accessToken = accessToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken", "The provided access token is null or blank. Please provide a non-null, valid access token");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
