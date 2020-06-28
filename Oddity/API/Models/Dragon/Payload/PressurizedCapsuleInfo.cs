using Newtonsoft.Json;
using Oddity.API.Models.Common;

namespace Oddity.API.Models.Capsule.Payload
{
    public class PressurizedCapsuleInfo
    {
        [JsonProperty("payload_volume")]
        public VolumeInfo PayloadVolume { get; set; }
    }
}
