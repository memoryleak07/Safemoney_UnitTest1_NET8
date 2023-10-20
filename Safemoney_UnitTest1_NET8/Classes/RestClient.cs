using Client.Models;

namespace Client.Classes
{
    public class RestClient
    {
        private string url;
        private HTTPClient client;

        public RestClient(string baseUrl)
        {
            client = new HTTPClient(baseUrl);
        }
        public RestClient(string baseUrl, string port)
        {
            client = new HTTPClient(baseUrl, port);
        }
        public RestClient(string address, string port, string username, string password)
        {
            client = new HTTPClient(address, port, username, password);
        }
        public async Task<SMResponse<SMBase>> Reboot()
        {
            HttpResponseMessage? res = await client.PutAsJsonAsync("reboot");
            return await ResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMResponse<SMBase>> PowerOff()
        {
            HttpResponseMessage? res = await client.PutAsJsonAsync("poweroff");
            return await ResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMResponse<SMPayCreated>> Pay(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("pay", payload);
            return await ResponseManager.ReadResponseAsync<SMPayCreated>(res);
        }
        public async Task<SMResponse<SMPay>> PayBegin(object payload)
        {
            var res = await client.PostAsJsonAsync("beginPayment", payload);
            return await ResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMResponse<SMPay>> PayDelete(object? payload)
        {
            var res = await client.DeleteAsJsonAsync("pay", payload);
            return await ResponseManager.ReadResponseAsync<SMPay>(res);
        }
    }
}
