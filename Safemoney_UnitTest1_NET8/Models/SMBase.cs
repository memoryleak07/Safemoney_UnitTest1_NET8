global using Newtonsoft.Json;

namespace Client.Models
{
    public class SMBase
    {
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("resCode")]
        public int ResCode { get; set; }

        [JsonProperty("resDescription")]
        public string ResDescription { get; set; }
    }
}
