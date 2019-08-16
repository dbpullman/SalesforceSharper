using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SalesforceSharper
{
    [Serializable, XmlRoot("QueryResult")]
    public class QueryResult<T>
    {
        [XmlElement("done")]
        public bool Done { get; set; }

        [XmlElement("totalSize")]
        public int TotalSize { get; set; }

        [XmlElement("records")]
        public List<T> Records { get; set; }

        [XmlElement("nextRecordsUrl")]
        public string NextRecordsUrl { get; set; }
    }
}
