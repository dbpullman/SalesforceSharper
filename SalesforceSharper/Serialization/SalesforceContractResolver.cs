using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SalesforceSharper.Attributes;

namespace SalesforceSharper.Serialization
{
    public class SalesforceContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var customAttribute = member.GetCustomAttribute<SalesforceFieldAttribute>();

            if (customAttribute == null || string.IsNullOrEmpty(customAttribute.Name))
                return property;

            property.PropertyName = customAttribute.Name;

            return property;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);

            return properties.Where(x => x != null).ToList();
        }
    }
}
