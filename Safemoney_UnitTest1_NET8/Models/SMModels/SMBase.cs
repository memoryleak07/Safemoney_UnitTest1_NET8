global using Newtonsoft.Json;

namespace Client.Models.SMModels
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SMBase
    {
        public string? Currency { get; set; }

        [JsonProperty("resCode")]
        public int? ResCode { get; set; }

        [JsonProperty("resDescription")]
        public string? ResDescription { get; set; }
    }
}
