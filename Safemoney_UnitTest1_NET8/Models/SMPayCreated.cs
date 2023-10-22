using Client.Models.SMEnum;

namespace Client.Models
{
    public class SMPayCreated : SMBase
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("transactionStatus")]
        public ETransactionStatus TransactionStatus { get; set; }
    }
}
