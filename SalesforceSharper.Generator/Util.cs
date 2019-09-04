using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Generator
{
    public static class Util
    {
        public static string UnderscoreToPascalCase(string name)
        {
            if (string.IsNullOrEmpty(name) || !name.Contains("_"))
            {
                return name;
            }
            string[] array = name.TrimEnd('_', 'c').Split('_');
            for (int i = 0; i < array.Length; i++)
            {
                string s = array[i];
                string first = string.Empty;
                string rest = string.Empty;
                if (s.Length > 0)
                {
                    first = char.ToUpperInvariant(s[0]).ToString();
                }
                if (s.Length > 1)
                {
                    rest = s.Substring(1);
                }
                array[i] = first + rest;
            }
            string newname = string.Join("", array);
            return newname;
        }
    }
}
