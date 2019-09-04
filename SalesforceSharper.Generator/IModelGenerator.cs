using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesforceSharper.Generator
{
    public interface IModelGenerator
    {
        string Generate(ObjectDescribeResponse describeResponse);
    }
}
