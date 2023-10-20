using Client.Models;
using System.Text;
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
        public async Task<SMBase> Reboot()
        {
            var res = await client.PutAsJsonAsync<SMBase>("reboot");
            return await ResponseManager.ReadResponse<SMBase>(res);
        }
        public async Task<SMBase> PowerOff()
        {
            var res = await client.PutAsJsonAsync<SMBase>("poweroff");
            return await ResponseManager.ReadResponse<SMBase>(res);
        }
        public async Task<SMPayCreated> Pay(object payload)
        {
            var res = await client.PostAsJsonAsync<dynamic>("pay", payload);
            return await ResponseManager.ReadResponse<SMPayCreated>(res);
        }
        public async Task<SMPay> PayBegin(object payload)
        {
            var res = await client.PostAsJsonAsync<dynamic>("beginPayment", payload);
            return await ResponseManager.ReadResponse<SMPay>(res);
        }
        public async Task<SMPay> PayDelete(object? payload)
        {
            var res = await client.DeleteAsJsonAsync<dynamic>("pay", payload);
            return await ResponseManager.ReadResponse<SMPay>(res);
        }
    }
}
