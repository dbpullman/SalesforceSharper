using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SalesforceSharp.Handlers
{
    public class ContentTypeHandler : DelegatingHandler
    {
        public ContentTypeHandler() : base(new HttpClientHandler())
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method.IsOneOf(HttpMethod.Post, HttpMethod.Put, new HttpMethod("PATCH")))
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
