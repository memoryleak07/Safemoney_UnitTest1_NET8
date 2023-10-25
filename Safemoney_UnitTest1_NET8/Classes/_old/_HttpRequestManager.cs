using Client.Models.SMModels;
using System.Net.Http.Json;

namespace Client.Classes._old
{
    public class HttpRequestManager(HttpClient httpClient)
    {
        private readonly HttpClient client = httpClient;
        // Generics
        public async Task<SMResponse<SMBase>> Reboot()
        {
            HttpResponseMessage? res = await client.PutAsync("reboot", null);
            return await SafemoneyResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMResponse<SMBase>> PowerOff()
        {
            HttpResponseMessage? res = await client.PutAsync("poweroff", null);
            return await SafemoneyResponseManager.ReadResponseAsync<SMBase>(res);
        }
        // Pay
        public async Task<SMResponse<SMPayCreated>> Pay(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("pay", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPayCreated>(res);
        }
        public async Task<SMResponse<SMPay>> PayBegin(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("beginPayment", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMResponse<SMPay>> PayDelete(object payload)
        {
            HttpRequestMessage request = HttpUtility.BuildRequestMessageFromObject(HttpMethod.Delete, "pay", payload);
            HttpResponseMessage res = await client.SendAsync(request);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        // Withdrawals
        public async Task<SMResponse<SMPayCreated>> WithdrawAsync(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("withdraw", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPayCreated>(res);
        }
        public async Task<SMResponse<SMPay>> FastWithdrawAsync(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("fastwithdraw", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMResponse<SMPay>> DeleteFastWithdrawAsync(object payload)
        {
            HttpRequestMessage request = HttpUtility.BuildRequestMessageFromObject(HttpMethod.Delete, "fastwithdraw", payload);
            HttpResponseMessage res = await client.SendAsync(request);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMResponse<SMDenominations>> GetCashWithdrawLevel()
        {
            HttpResponseMessage? res = await client.GetAsync("cashWithdrawLevel");
            return await SafemoneyResponseManager.ReadResponseAsync<SMDenominations>(res);
        }
        public async Task<SMResponse<SMCashWithdraw>> PostCashWithdrawLevel(object payload)
        {
            HttpResponseMessage? res = await client.PostAsJsonAsync("cashWithdrawLevel", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMCashWithdraw>(res);
        }
        // Inventory
        public async Task<SMResponse<SMInventory>> GetInventoryAsync()
        {
            HttpResponseMessage? res = await client.GetAsync("inventory");
            return await SafemoneyResponseManager.ReadResponseAsync<SMInventory>(res);
        }
        // TransactionLog
        public async Task<SMResponse<SMTransactionsLog>> GetTransactionsLogAsync()
        {
            HttpResponseMessage? res = await client.GetAsync("transactionsLog?offset=0&limit=10&datefrom=2022-04-09&dateto=2022-04-12");
            return await SafemoneyResponseManager.ReadResponseAsync<SMTransactionsLog>(res);
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
