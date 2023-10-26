using Client.Classes;
using Client.Interfaces;
using Client.Models.Safemoney.SMModels;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;


namespace Client.Controllers
{
    public class SafemoneyService : ISafemoneyService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SafemoneyService> _logger;

        public SafemoneyService(IHttpClientFactory factory, ILogger<SafemoneyService> logger)
        {
            _httpClient = factory.CreateClient("safemoney");
            _logger = logger;
        }

        // Generics
        public async Task<SMBaseResponse<SMBase>> Reboot()
        {
            HttpResponseMessage? res = await _httpClient.PutAsync("reboot", null);
            return await SafemoneyResponseManager.ReadResponseAsync<SMBase>(res);
        }
        public async Task<SMBaseResponse<SMBase>> PowerOff()
        {
            HttpResponseMessage? res = await _httpClient.PutAsync("poweroff", null);
            return await SafemoneyResponseManager.ReadResponseAsync<SMBase>(res);
        }
        // Pay
        public async Task<SMBaseResponse<SMPayCreated>> Pay(object payload)
        {
            _logger.LogInformation("Log Pay");
            HttpResponseMessage? res = await _httpClient.PostAsJsonAsync("pay", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPayCreated>(res);
        }
        public async Task<SMBaseResponse<SMPay>> PayBegin(object payload)
        {
            HttpResponseMessage? res = await _httpClient.PostAsJsonAsync("beginPayment", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMBaseResponse<SMPay>> PayDelete(object payload)
        {
            HttpRequestMessage request = HttpUtility.BuildRequestMessageFromObject(HttpMethod.Delete, "pay", payload);
            HttpResponseMessage res = await _httpClient.SendAsync(request);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        // Withdrawals
        public async Task<SMBaseResponse<SMPayCreated>> WithdrawAsync(object payload)
        {
            HttpResponseMessage? res = await _httpClient.PostAsJsonAsync("withdraw", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPayCreated>(res);
        }
        public async Task<SMBaseResponse<SMPay>> FastWithdrawAsync(object payload)
        {
            HttpResponseMessage? res = await _httpClient.PostAsJsonAsync("fastwithdraw", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMBaseResponse<SMPay>> DeleteFastWithdrawAsync(object payload)
        {
            HttpRequestMessage request = HttpUtility.BuildRequestMessageFromObject(HttpMethod.Delete, "fastwithdraw", payload);
            HttpResponseMessage res = await _httpClient.SendAsync(request);
            return await SafemoneyResponseManager.ReadResponseAsync<SMPay>(res);
        }
        public async Task<SMBaseResponse<SMDenominations>> GetCashWithdrawLevel()
        {
            HttpResponseMessage? res = await _httpClient.GetAsync("cashWithdrawLevel");
            return await SafemoneyResponseManager.ReadResponseAsync<SMDenominations>(res);
        }
        public async Task<SMBaseResponse<SMCashWithdraw>> PostCashWithdrawLevel(object payload)
        {
            HttpResponseMessage? res = await _httpClient.PostAsJsonAsync("cashWithdrawLevel", payload);
            return await SafemoneyResponseManager.ReadResponseAsync<SMCashWithdraw>(res);
        }
        // Inventory
        public async Task<SMBaseResponse<SMInventory>> GetInventoryAsync()
        {
            HttpResponseMessage? res = await _httpClient.GetAsync("inventory");
            return await SafemoneyResponseManager.ReadResponseAsync<SMInventory>(res);
        }
        // TransactionLog
        public async Task<SMBaseResponse<SMTransactionsLog>> GetTransactionsLogAsync()
        {
            HttpResponseMessage? res = await _httpClient.GetAsync("transactionsLog?offset=0&limit=10&datefrom=2022-04-09&dateto=2022-04-12");
            return await SafemoneyResponseManager.ReadResponseAsync<SMTransactionsLog>(res);
        }
        // Home test only
        public async Task<HttpResponseMessage> MyGetMethodAsync()
        {
            return await _httpClient.GetAsync("get");
        }
        public async Task<HttpResponseMessage> MyPostMethodAsync(object? payload)
        {
            return await _httpClient.PostAsJsonAsync("post", payload);
        }
        public async Task<HttpResponseMessage> MyPutMethodAsync()
        {
            return await _httpClient.PutAsync("put", null);
        }
        public async Task<HttpResponseMessage> MyDeleteMethodAsync()
        {
            return await _httpClient.DeleteAsync("delete");
        }


    }
}
