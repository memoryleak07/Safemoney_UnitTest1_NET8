namespace Client.Models
{
    public class SMPay : SMBase
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dispensed")]
        public double Dispensed { get; set; }

        [JsonProperty("notDispensed")]
        public double NotDispensed { get; set; }

        [JsonProperty("paid")]
        public double Paid { get; set; }

        [JsonProperty("toBePaid")]
        public double ToBePaid { get; set; }

        [JsonProperty("transactionStatus")]
        public SMTransactionStatus TransactionStatus { get; set; }
    }
}
