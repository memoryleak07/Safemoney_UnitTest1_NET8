using Client.Classes;
using Client.Interfaces;
using Client.Models.SMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class SafemoneyController : ISafemoneyService
    {
        private readonly ISafemoneyService _httpClient;
        private HttpClient httpClient;

        public SafemoneyController(ISafemoneyService httpClient)
        {
            _httpClient = httpClient;
        }

        public SafemoneyController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // Generics
        public async Task<SMResponse<SMBase>> Reboot()
        {
            HttpResponseMessage? res = await httpClient.PutAsync("reboot", null);
            return await SafemoneyResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMResponse<SMBase>> PowerOff()
        {
            HttpResponseMessage? res = await httpClient.PutAsync("poweroff", null);
            return await SafemoneyResponseManager.ReadResponseAsync<SMBase>(res);
        }
        // Pay
        public async Task<SMResponse<SMPayCreated>> Pay(object payload)
        {
            HttpResponseMessage? res = await httpClient.PostAsJsonAsync("pay", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPayCreated>(res);
        }
        public async Task<SMResponse<SMPay>> PayBegin(object payload)
        {
            HttpResponseMessage? res = await httpClient.PostAsJsonAsync("beginPayment", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMResponse<SMPay>> PayDelete(object payload)
        {
            HttpRequestMessage request = HttpUtility.BuildRequestMessageFromObject(HttpMethod.Delete, "pay", payload);
            HttpResponseMessage res = await httpClient.SendAsync(request);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        // Withdrawals
        public async Task<SMResponse<SMPayCreated>> WithdrawAsync(object payload)
        {
            HttpResponseMessage? res = await httpClient.PostAsJsonAsync("withdraw", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPayCreated>(res);
        }
        public async Task<SMResponse<SMPay>> FastWithdrawAsync(object payload)
        {
            HttpResponseMessage? res = await httpClient.PostAsJsonAsync("fastwithdraw", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMResponse<SMPay>> DeleteFastWithdrawAsync(object payload)
        {
            HttpRequestMessage request = HttpUtility.BuildRequestMessageFromObject(HttpMethod.Delete, "fastwithdraw", payload);
            HttpResponseMessage res = await httpClient.SendAsync(request);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMResponse<SMDenominations>> GetCashWithdrawLevel()
        {
            HttpResponseMessage? res = await httpClient.GetAsync("cashWithdrawLevel");
            return await SafemoneyResponseManager.ReadResponseAsync<SMDenominations>(res);
        }
        public async Task<SMResponse<SMCashWithdraw>> PostCashWithdrawLevel(object payload)
        {
            HttpResponseMessage? res = await httpClient.PostAsJsonAsync("cashWithdrawLevel", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMCashWithdraw>(res);
        }
        // Inventory
        public async Task<SMResponse<SMInventory>> GetInventoryAsync()
        {
            HttpResponseMessage? res = await httpClient.GetAsync("inventory");
            return await SafemoneyResponseManager.ReadResponseAsync<SMInventory>(res);
        }
        // TransactionLog
        public async Task<SMResponse<SMTransactionsLog>> GetTransactionsLogAsync()
        {
            HttpResponseMessage? res = await httpClient.GetAsync("transactionsLog?offset=0&limit=10&datefrom=2022-04-09&dateto=2022-04-12");
            return await SafemoneyResponseManager.ReadResponseAsync<SMTransactionsLog>(res);
        }
        // Home test only
        public async Task<HttpResponseMessage> MyGetMethodAsync()
        {
            return await httpClient.GetAsync("get");
        }
        public async Task<HttpResponseMessage> MyPostMethodAsync(object? payload)
        {
            return await httpClient.PostAsJsonAsync("post", payload);
        }
        public async Task<HttpResponseMessage> MyPutMethodAsync()
        {
            return await httpClient.PutAsync("put", null);
        }
        public async Task<HttpResponseMessage> MyDeleteMethodAsync()
        {
            return await httpClient.DeleteAsync("delete");
        }


    }
}
