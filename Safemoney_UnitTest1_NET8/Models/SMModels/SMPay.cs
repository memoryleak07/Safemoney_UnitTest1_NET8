using Client.Models.SMEnum;

namespace Client.Models.SMModels
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
        public ETransactionStatus TransactionStatus { get; set; }
    }
}
