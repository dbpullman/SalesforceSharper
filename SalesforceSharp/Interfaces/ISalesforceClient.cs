using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesforceSharp.Interfaces
{
    public interface ISalesforceClient
    {
        Task<List<T>> Query<T>(string query);
        Task<List<T>> QueryAll<T>(string query);
        Task<string> Create<T>(T record);
        Task<bool> Update<T>(string id, T record);
        Task<bool> Delete<T>(string id);
    }
}