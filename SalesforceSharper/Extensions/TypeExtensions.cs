using SalesforceSharper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper
{
    public static class TypeExtensions
    {
        public static string GetObjectName(this object obj)
        {
            return obj.GetType()
                .GetObjectName();
        }

        public static string GetObjectName(this Type type)
        {
            var salesforceObjectAttribute = type.GetCustomAttribute<SalesforceObjectAttribute>();
            if (salesforceObjectAttribute != null && !string.IsNullOrEmpty(salesforceObjectAttribute.Name))
                return salesforceObjectAttribute.Name;

            return type.Name;
        }
    }
}
