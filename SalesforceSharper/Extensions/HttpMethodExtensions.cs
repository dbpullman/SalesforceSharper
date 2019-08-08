using System;
using System.Net.Http;

namespace SalesforceSharp
{
    public static class HttpMethodExtensions
    {
        public static bool IsOneOf(this HttpMethod httpMethod, params HttpMethod[] methods)
        {
            foreach (HttpMethod method in methods)
            {
                if (httpMethod.Method.Equals(method.Method, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
