using Client.Models.SMEnum;

namespace Client.Models
{
    public class SMCashWithdraw : SMBase
    {
        [JsonProperty("totalDispensed", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalDispensed { get; set; }

        [JsonProperty("totalNotDispensed", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalNotDispensed { get; set; }

        [JsonProperty("withdrawals", NullValueHandling = NullValueHandling.Ignore)]
        public List<SMDenominations> Withdrawals { get; set; }

        [JsonProperty("transactionStatus", NullValueHandling = NullValueHandling.Ignore)]
        public ETransactionStatus TransactionStatus { get; set; }
    }
}
