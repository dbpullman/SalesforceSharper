using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharp.Attributes
{
    public class SalesforceObjectAttribute : Attribute
    {
        public SalesforceObjectAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
