using System.Net.Http;
using System.Threading.Tasks;

namespace SalesforceSharp.Serialization
{
    public interface ISerializer
    {
        string Serialize(object obj);
        T Deserialize<T>(string json);
    }
}
