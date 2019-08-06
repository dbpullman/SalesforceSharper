using System.Collections.Generic;

namespace SalesforceSharp
{
    public class QueryResult<T>
    {
        public bool Done { get; set; }
        public int TotalSize { get; set; }
        public List<T> Records { get; set; }
        public string NextRecordsUrl { get; set; }
    }
}
