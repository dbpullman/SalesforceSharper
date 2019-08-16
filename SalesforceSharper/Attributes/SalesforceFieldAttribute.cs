using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Attributes
{
    public class SalesforceFieldAttribute : Attribute
    {
        public SalesforceFieldAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
