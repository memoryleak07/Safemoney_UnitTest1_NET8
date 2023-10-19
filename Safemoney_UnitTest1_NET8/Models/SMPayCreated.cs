namespace Client.Models
{
    public class SMPayCreated : SMBase
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("transactionStatus")]
        public SMTransactionStatus TransactionStatus { get; set; }
    }
}
