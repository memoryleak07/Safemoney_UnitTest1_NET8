using Client.Models.SMEnum;

namespace Client.Models
{
    public class SMDenominations
    {
        public SMDenominations(EDeviceType deviceType, double denomination, int quantity)
        {
            DeviceType = deviceType;
            Denomination = denomination;
            Quantity = quantity;
        }

        [JsonProperty("dispensed", NullValueHandling = NullValueHandling.Ignore)]
        public double? Dispensed { get; set; } = null;

        [JsonProperty("notDispensed", NullValueHandling = NullValueHandling.Ignore)]
        public double NotDispensed { get; set; }

        [JsonProperty("cbLevel", NullValueHandling = NullValueHandling.Ignore)]
        public int CbLevel { get; set; }

        [JsonProperty("delta", NullValueHandling = NullValueHandling.Ignore)]
        public int Delta { get; set; }

        [JsonProperty("denomination", NullValueHandling = NullValueHandling.Ignore)]
        public double Denomination { get; set; }

        [JsonProperty("deviceType", NullValueHandling = NullValueHandling.Ignore)]
        public EDeviceType DeviceType { get; set; }

        [JsonProperty("maxThreshold", NullValueHandling = NullValueHandling.Ignore)]
        public int MaxThreshold { get; set; }

        [JsonProperty("minThreshold", NullValueHandling = NullValueHandling.Ignore)]
        public int MinThreshold { get; set; }

        [JsonProperty("reLevel", NullValueHandling = NullValueHandling.Ignore)]
        public int ReLevel { get; set; }

        [JsonProperty("route", NullValueHandling = NullValueHandling.Ignore)]
        public ERoute Route { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int Quantity { get; set; }
    }
}