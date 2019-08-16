using SalesforceSharper.Handlers;
using SalesforceSharper.Interfaces;
using SalesforceSharper.Serialization;
using SalesforceSharper.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace SalesforceSharper
{
    public class SalesforceClient : ISalesforceClient
    {
        private readonly HttpClient httpClient;
        private readonly ISerializer serializer;
        private readonly string apiVersion;

        public SalesforceClient(string instanceUrl, string accessToken)
            : this(instanceUrl, accessToken, "v45.0", new JsonSerializer())
        {

        }

        public SalesforceClient(string instanceUrl, string accessToken, string apiVersion)
            : this(instanceUrl, accessToken, apiVersion, new JsonSerializer())
        {
        }

        public SalesforceClient(string instanceUrl, string accessToken, ISerializer serializer)
            : this(instanceUrl, accessToken, "v45.0", serializer)
        { }

        public SalesforceClient(string instanceUrl, string accessToken, string apiVersion, ISerializer serializer)
        {
            httpClient = new HttpClient(new AuthenticationHeaderHandler(accessToken))
            {
                BaseAddress = new Uri(instanceUrl)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(serializer.ContentType));

            this.apiVersion = apiVersion;
            this.serializer = serializer;
        }

        public async Task<string> Create<T>(T record)
        {
            return await Create(typeof(T).GetObjectName(), record);
        }

        public async Task<string> Create<T>(string objectName, T record)
        {
            var url = new SObjectUrlBuilder(apiVersion)
                .ForSObject(objectName)
                .ToString();

            var body = new StringContent(serializer.Serialize(record), Encoding.UTF8, serializer.ContentType);
            var response = await httpClient.PostAsync(url, body);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var success = serializer.Deserialize<CreatedResponse>(content);

                if (success.Success)
                    return success.Id;
            }

            return null;
        }

        public async Task<bool> Delete(string sObjectName, string id)
        {
            var url = new SObjectUrlBuilder(apiVersion)
                .ForSObject(sObjectName)
                .WithId(id)
                .ToString();

            var response = await httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete<T>(string id)
        {
            return await Delete(typeof(T).GetObjectName(), id);
        }

        public async Task<List<T>> Query<T>(string query)
        {
            var url = new QueryUrlBuilder(apiVersion)
                .WithQuery(query)
                .ToString();

            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var result = serializer.Deserialize<QueryResult<T>>(content);

            return result.Records;

        }

        private async Task<QueryResult<T>> QueryMore<T>(string url)
        {
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var result = serializer.Deserialize<QueryResult<T>>(content);
            return result;
        }

        public async Task<List<T>> QueryAll<T>(string query)
        {
            var records = new List<T>();
            string url = new QueryUrlBuilder(apiVersion).WithQuery(query).ToString();
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var result = serializer.Deserialize<QueryResult<T>>(content);
            records.AddRange(result.Records);

            while (!string.IsNullOrEmpty(result.NextRecordsUrl))
            {
                result = await QueryMore<T>(result.NextRecordsUrl);
                records.AddRange(result.Records);
            }

            return records;
        }

        public async Task<bool> Update<T>(string sObjectName, string id, T record)
        {
            var url = new SObjectUrlBuilder(apiVersion)
                .ForSObject(sObjectName)
                .WithId(id)
                .ToString();

            //var body = new StringContent(serializer.Serialize(record));
            var content = new StringContent(serializer.Serialize(record), Encoding.UTF8, serializer.ContentType);
            var response = await httpClient.PatchAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update<T>(string id, T record)
        {
            return await Update(record.GetObjectName(), id, record);
        }

        public async Task<T> GetById<T>(string sObjectName, string id)
        {
            var url = new SObjectUrlBuilder(apiVersion)
                .ForSObject(sObjectName)
                .WithId(id)
                .ToString();

            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return serializer.Deserialize<T>(content);
        }

        public async Task<T> GetById<T>(string id)
        {
            return await GetById<T>(typeof(T).GetObjectName(), id);
        }
    }
}
