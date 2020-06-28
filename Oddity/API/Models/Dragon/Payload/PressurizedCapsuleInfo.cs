using Newtonsoft.Json;
using Oddity.API.Models.Common;

namespace Oddity.API.Models.Dragon.Payload
{
    public class PressurizedCapsuleInfo
    {
        [JsonProperty("payload_volume")]
        public VolumeInfo PayloadVolume { get; set; }
    }
}
