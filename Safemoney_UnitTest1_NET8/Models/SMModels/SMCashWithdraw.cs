using Client.Models.SMEnum;

namespace Client.Models.SMModels
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SMCashWithdraw : SMBase
    {
        [JsonProperty("totalDispensed")]
        public double? TotalDispensed { get; set; }

        [JsonProperty("totalNotDispensed")]
        public double? TotalNotDispensed { get; set; }

        [JsonProperty("withdrawals")]
        public List<SMDenominations>? Withdrawals { get; set; }

        [JsonProperty("transactionStatus")]
        public ETransactionStatus? TransactionStatus { get; set; }
    }
}
