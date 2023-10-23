namespace Client.Models
{
    public class SMCashLevel : SMBase
    {
        [JsonProperty("cashList", NullValueHandling = NullValueHandling.Ignore)]
        public List<SMDenominations>? CashList { get; set; }

        [JsonProperty("withdrawals", NullValueHandling = NullValueHandling.Ignore)]
        public List<SMDenominations>? Withdrawals { get; set; }
    }
}
