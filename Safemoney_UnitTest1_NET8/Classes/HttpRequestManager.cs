using Client.Models;
using System.Net.Http.Json;

namespace Client.Classes
{
    public class HttpRequestManager(HttpClient httpClient)
    {
        private readonly HttpClient client = httpClient;

        public async Task<SMResponse<SMBase>> Reboot()
        {
            HttpResponseMessage? res = await client.PutAsync("reboot", null);
            return await HttpResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMResponse<SMBase>> PowerOff()
        {
            HttpResponseMessage? res = await client.PutAsync("poweroff", null);
            return await HttpResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMResponse<SMPayCreated>> Pay(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("pay", payload);
            return await HttpResponseManager.ReadResponseAsync<SMPayCreated>(res);
        }
        public async Task<SMResponse<SMPay>> PayBegin(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("beginPayment", payload);
            return await HttpResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMResponse<SMPay>> PayDelete(object payload)
        {
            HttpRequestMessage request = HttpUtility.BuildRequestMessageFromObject(HttpMethod.Delete, "pay", payload);
            HttpResponseMessage res = await client.SendAsync(request);
            return await HttpResponseManager.ReadResponseAsync<SMPay>(res);
        }
        // Home test only
        public async Task<HttpResponseMessage> MyGetMethodAsync()
        {
            return await client.GetAsync("get");
        }
        public async Task<HttpResponseMessage> MyPostMethodAsync(object? payload)
        {
            return await client.PostAsJsonAsync("post", payload);
        }
        public async Task<HttpResponseMessage> MyPutMethodAsync()
        {
            return await client.PutAsync("put", null);
        }
        public async Task<HttpResponseMessage> MyDeleteMethodAsync()
        {
            return await client.DeleteAsync("delete");
        }
    }
}
