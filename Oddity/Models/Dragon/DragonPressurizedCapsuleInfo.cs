using Newtonsoft.Json;
using Oddity.Models.Common;

namespace Oddity.Models.Dragon
{
    public class DragonPressurizedCapsuleInfo : ModelBase
    {
        [JsonProperty("payload_volume")]
        public VolumeInfo PayloadVolume { get; set; }
    }
}
