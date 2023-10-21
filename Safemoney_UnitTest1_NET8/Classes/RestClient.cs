using Client.Models;
using System.Net.Http.Json;

namespace Client.Classes
{
    public class RestClient
    {
        public HttpClient client = new(); // Init a new instance of the HttpClient
        public HttpClient HttpClient => client; // Expose the HttpClient to use built-in methods 
        public RestClient(string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress);
        }
        public RestClient(string baseAddress, string port)
        {
            client.BaseAddress = new Uri(baseAddress + port);
        }
        public RestClient(string baseAddress, string port, string username, string password)
        {
            client.BaseAddress = new Uri(baseAddress + port);
            HttpUtility.AddHttpRequestHeaders(client, username, password);
        }
        public async Task<SMResponse<SMBase>> Reboot()
        {
            HttpResponseMessage? res = await client.PutAsync("reboot", null);
            return await ResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMResponse<SMBase>> PowerOff()
        {
            HttpResponseMessage? res = await client.PutAsync("poweroff", null);
            return await ResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMResponse<SMPayCreated>> Pay(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("pay", payload);
            return await ResponseManager.ReadResponseAsync<SMPayCreated>(res);
        }
        public async Task<SMResponse<SMPay>> PayBegin(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("beginPayment", payload);
            return await ResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMResponse<SMPay>> PayDelete(object payload)
        {
            var request = HttpUtility.BuildRequestMessageFromObject(HttpMethod.Delete, "pay", payload);
            var res = await client.SendAsync(request);
            return await ResponseManager.ReadResponseAsync<SMPay>(res);
        }
        // Home test only
        public async Task<HttpResponseMessage> MyGetMethod1()
        {
            return await client.GetAsync("get");
        }
        public async Task<HttpResponseMessage> MyPostMethod1(object? payload)
        {
            return await client.PostAsJsonAsync("post", payload);
        }
        public async Task<HttpResponseMessage> MyPutMethod1()
        {
            return await client.PutAsync("put", null);
        }
        public async Task<HttpResponseMessage> MyDeleteMethod1()
        {
            return await client.DeleteAsync("delete");
        }
    }
}
