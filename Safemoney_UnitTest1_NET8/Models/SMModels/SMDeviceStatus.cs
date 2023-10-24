using Client.Models.SMEnum;

namespace Client.Models.SMModels
{
    public class SMDeviceStatus : SMBase
    {
        [JsonProperty("deviceStatus")]
        public EDeviceStatus DeviceStatus { get; set; }

        [JsonProperty("statusInfo")]
        public List<SMStatusInfo> StatusInfo { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}
