using SalesforceSharper.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Serialization
{
    public class XmlSerializer : ISerializer
    {
        public string ContentType => "application/xml";

        public T Deserialize<T>(string json)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var reader = new StringReader(json))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public string Serialize(object obj)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using(var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();

            }
        }
    }
}
