using Client.Models.SMEnum;

namespace Client.Models.SMModels
{
    public class SMTransactionsLogBase : SMTransactionsLog
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("TransactionCode")]
        public ETransactionCode TransactionCode { get; set; }

        [JsonProperty("Token", NullValueHandling = NullValueHandling.Ignore)]
        public object Token { get; set; } // Assuming Token can be null

        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("TotalRequest")]
        public double TotalRequest { get; set; }

        [JsonProperty("Paid")]
        public double Paid { get; set; }

        [JsonProperty("Dispensed")]
        public double Dispensed { get; set; }

        [JsonProperty("NotDispensed")]
        public double NotDispensed { get; set; }

        [JsonProperty("TransactionStatus", NullValueHandling = NullValueHandling.Ignore)]
        public ETransactionStatus TransactionStatus { get; set; }

        [JsonProperty("ResCode")]
        public int ResCode { get; set; }

        [JsonProperty("ResDescription")]
        public string ResDescription { get; set; }

        [JsonProperty("Total")]
        public double Total { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Levels")]
        public SMInventory Levels { get; set; }

        [JsonProperty("User")]
        public string User { get; set; }
    }

}
