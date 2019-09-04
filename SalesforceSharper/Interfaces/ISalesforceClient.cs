using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesforceSharper.Interfaces
{
    public interface ISalesforceClient
    {
        Task<List<T>> Query<T>(string query);
        Task<List<T>> QueryAll<T>(string query);
        Task<string> Create<T>(T record);
        Task<bool> Update<T>(string id, T record);
        Task<bool> Delete<T>(string id);
        Task<T> GetById<T>(string id);
        Task<ObjectDescribeResponse> DescribeObject(string sObjectName);
    }
}