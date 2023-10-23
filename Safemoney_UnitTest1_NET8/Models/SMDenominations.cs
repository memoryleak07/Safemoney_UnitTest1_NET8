using Client.Models.SMEnum;
using System.Text.Json.Serialization;

namespace Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SMDenominations : SMBase
    {
        public SMDenominations(EDeviceType deviceType, double denomination, int quantity)
        {
            DeviceType = deviceType;
            Denomination = denomination;
            Quantity = quantity;
        }

        [JsonProperty("dispensed")]
        public double? Dispensed { get; set; } = null;

        [JsonProperty("notDispensed")]
        public double? NotDispensed { get; set; }

        [JsonProperty("cbLevel")]
        public int? CbLevel { get; set; }

        [JsonProperty("delta")]
        public int? Delta { get; set; }

        [JsonProperty("denomination")]
        public double? Denomination { get; set; }

        [JsonProperty("deviceType")]
        public EDeviceType? DeviceType { get; set; }

        [JsonProperty("maxThreshold")]
        public int? MaxThreshold { get; set; }

        [JsonProperty("minThreshold")]
        public int? MinThreshold { get; set; }

        [JsonProperty("reLevel")]
        public int? ReLevel { get; set; }

        [JsonProperty("route")]
        public ERoute? Route { get; set; }

        [JsonProperty("total")]
        public double? Total { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
    }
}