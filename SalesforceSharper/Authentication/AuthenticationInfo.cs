using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SalesforceSharper.Authentication
{
    [Serializable, XmlRoot("OAuth")]
    public class AuthenticationInfo
    {
        [XmlElement("access_token")]
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [XmlElement("instance_url")]
        [JsonProperty("instance_url")]
        public string InstanceUrl { get; set; }
    }
}
