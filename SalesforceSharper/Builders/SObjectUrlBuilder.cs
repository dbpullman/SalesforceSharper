using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Builders
{
    public class SObjectUrlBuilder : UrlBuilder
    {
        public SObjectUrlBuilder(string apiVersion) : base(apiVersion)
        {
        }

        public SObjectUrlBuilder ForSObject(string name)
        {
            url = $"/services/data/{apiVersion}/sobjects/{name}";
            return this;
        }

        public SObjectUrlBuilder WithId(string id)
        {
            url = $"{url}/{id}";
            return this;
        }
    }
}
