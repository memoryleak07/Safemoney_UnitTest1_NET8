namespace Client.Models.Safemoney.SMModels
{
    public class SMStatusInfo
    {
        [JsonProperty("data")]
        public SMStatusInfoData? Data { get; set; }

        [JsonProperty("statusCode")]
        public string? StatusCode { get; set; }
    }
    public class SMStatusInfoData
    {
        [JsonProperty("UID")]
        public string? UID { get; set; }

        [JsonProperty("Code")]
        public string? Code { get; set; }

        [JsonProperty("Status")]
        public string? Status { get; set; }

        [JsonProperty("InError")]
        public bool InError { get; set; }

        [JsonProperty("Type")]
        public int? Type { get; set; }
    }
}
