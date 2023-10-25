using Client.Models.SMModels;


namespace Client.Interfaces
{
    public interface ISafemoneyService
    {
        // Generics
        Task<SMResponse<SMBase>> Reboot();
        Task<SMResponse<SMBase>> PowerOff();
        // Pay
        Task<SMResponse<SMPayCreated>> Pay(object payload);
        Task<SMResponse<SMPay>> PayBegin(object payload);
        Task<SMResponse<SMPay>> PayDelete(object payload);
        // Withdrawals
        Task<SMResponse<SMPayCreated>> WithdrawAsync(object payload);
        Task<SMResponse<SMPay>> FastWithdrawAsync(object payload);
        Task<SMResponse<SMPay>> DeleteFastWithdrawAsync(object payload);
        Task<SMResponse<SMDenominations>> GetCashWithdrawLevel();
        Task<SMResponse<SMCashWithdraw>> PostCashWithdrawLevel(object payload);
        // Inventory
        Task<SMResponse<SMInventory>> GetInventoryAsync();
        // TransactionLog
        Task<SMResponse<SMTransactionsLog>> GetTransactionsLogAsync();
        // Home test only
        Task<HttpResponseMessage> MyGetMethodAsync();
        Task<HttpResponseMessage> MyPostMethodAsync(object? payload);
        Task<HttpResponseMessage> MyPutMethodAsync();
        Task<HttpResponseMessage> MyDeleteMethodAsync();
    }
}
