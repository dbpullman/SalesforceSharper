using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper
{
    public class ObjectDescribeResponse
    {
        public string Name { get; set; }
        public string Label { get; set; }

        public List<Field> Fields { get; set; }
    }
}
