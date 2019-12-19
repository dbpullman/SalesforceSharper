using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Generator
{
    public class UsingStatement
    {
        public string Name { get; set; }

        public UsingStatement(string name)
        {
            Name = name;
        }

        public UsingStatement()
        { }
    }
}
