using Client.Models.Safemoney.SMModels;

namespace Client.Interfaces
{
    public interface ISafemoneyService
    {
        // Generics
        Task<SMBaseResponse<SMBase>> Reboot();
        Task<SMBaseResponse<SMBase>> PowerOff();
        // Pay
        Task<SMBaseResponse<SMPayCreated>> Pay(object payload);
        Task<SMBaseResponse<SMPay>> PayBegin(object payload);
        Task<SMBaseResponse<SMPay>> PayDelete(object payload);
        // Withdrawals
        Task<SMBaseResponse<SMPayCreated>> WithdrawAsync(object payload);
        Task<SMBaseResponse<SMPay>> FastWithdrawAsync(object payload);
        Task<SMBaseResponse<SMPay>> DeleteFastWithdrawAsync(object payload);
        Task<SMBaseResponse<SMDenominations>> GetCashWithdrawLevel();
        Task<SMBaseResponse<SMCashWithdraw>> PostCashWithdrawLevel(object payload);
        // Inventory
        Task<SMBaseResponse<SMInventory>> GetInventoryAsync();
        // TransactionLog
        Task<SMBaseResponse<SMTransactionsLog>> GetTransactionsLogAsync();
        // Home test only
        Task<HttpResponseMessage> MyGetMethodAsync();
        Task<HttpResponseMessage> MyPostMethodAsync(object? payload);
        Task<HttpResponseMessage> MyPutMethodAsync();
        Task<HttpResponseMessage> MyDeleteMethodAsync();
    }
}
