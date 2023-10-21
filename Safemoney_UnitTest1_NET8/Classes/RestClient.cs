using Client.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Client.Classes
{
    public class RestClient : HttpClient
    {
        public string url;
        public readonly HttpClient client;
        public RestClient(string baseAddress)
        {
            BaseAddress = new Uri(baseAddress);
        }
        public RestClient(string baseAddress, string port, string username, string password)
        {
            url = baseAddress + port;
            BaseAddress = new Uri(url);

            // Create the Authorization header and set it directly on the HttpClient headers
            string authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authValue);

            // Set the default Accept header if needed
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<SMResponse<SMBase>> Reboot()
        {
            HttpResponseMessage? res = await client.PutAsJsonAsync(url, "reboot");
            return await ResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMResponse<SMBase>> PowerOff()
        {
            HttpResponseMessage? res = await client.PutAsJsonAsync(url, "poweroff");
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
        public async Task<SMResponse<SMPay>> PayDelete(object? payload)
        {
            var request = HttpUtility.BuildRequestFromObject(HttpMethod.Delete, url+"pay", payload);
            var res = await client.SendAsync(request);
            return await ResponseManager.ReadResponseAsync<SMPay>(res);
        }
    }
}
