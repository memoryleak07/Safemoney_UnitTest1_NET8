namespace Client.Models.Safemoney.SMModels
{
    public class SMInventory : SMBase
    {
        [JsonProperty("coins")]
        public InventoryDeviceType Coins { get; set; }

        [JsonProperty("notes")]
        public InventoryDeviceType Notes { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

    }

    public class InventoryDeviceType
    {
        [JsonProperty("denominations")]
        public List<SMDenominations> Denominations { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }
    }
}
