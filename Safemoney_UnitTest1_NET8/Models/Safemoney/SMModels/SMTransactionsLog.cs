namespace Client.Models.Safemoney.SMModels
{
    public class SMTransactionsLog : SMBase
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("transactionsLog")]
        public List<SMTransactionsLogList>? TransactionsLog { get; set; }
    }
}
