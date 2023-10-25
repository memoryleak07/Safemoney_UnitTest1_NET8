using Client.Models.Safemoney.SMEnum;

namespace Client.Models.Safemoney.SMModels
{
    public class SMPayCreated : SMBase
    {
        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("transactionStatus")]
        public ETransactionStatus? TransactionStatus { get; set; }
    }
}
