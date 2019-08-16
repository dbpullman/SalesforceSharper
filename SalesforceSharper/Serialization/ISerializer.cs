using System.Net.Http;
using System.Threading.Tasks;

namespace SalesforceSharper.Serialization
{
    public interface ISerializer
    {
        string Serialize(object obj);
        T Deserialize<T>(string json);

        string ContentType { get; }
    }
}
