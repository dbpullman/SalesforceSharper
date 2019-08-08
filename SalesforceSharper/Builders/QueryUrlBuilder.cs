using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharp.Builders
{
    public class QueryUrlBuilder : UrlBuilder
    {
        public QueryUrlBuilder(string apiVersion) : base(apiVersion)
        {
        }

        public QueryUrlBuilder WithQuery(string query)
        {
            url = $"/services/data/{apiVersion}/query/?q={query}";
            return this;
        }
    }
}
