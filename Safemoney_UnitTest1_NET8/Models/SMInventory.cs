namespace Client.Models
{
    public class SMInventory : SMBase
    {
        [JsonProperty("coins")]
        public InventoryDeviceType Coins { get; set; }

        [JsonProperty("notes")]
        public InventoryDeviceType Notes { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

    }

    public class InventoryDeviceType
    {
        [JsonProperty("denominations")]
        public List<SMDenominations> Denominations { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
