﻿namespace Client.Models
{
    public class SMTransactionsLog : SMBase
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("transactionsLog")]
        public List<SMTransactionsLogBase> TransactionsLog { get; set; }
    }
}
