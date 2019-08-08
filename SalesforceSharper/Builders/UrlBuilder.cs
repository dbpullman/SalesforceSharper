using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharp.Builders
{
    public abstract class UrlBuilder
    {
        protected readonly string apiVersion;
        protected string url;

        public UrlBuilder(string apiVersion)
        {
            url = string.Empty;
            this.apiVersion = apiVersion;
        }

        public override string ToString()
        {
            return url;
        }
    }
}
