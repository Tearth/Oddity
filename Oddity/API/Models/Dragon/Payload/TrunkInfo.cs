using Newtonsoft.Json;
using Oddity.API.Models.Common;

namespace Oddity.API.Models.Dragon.Payload
{
    public class TrunkInfo
    {
        [JsonProperty("trunk_volume")]
        public VolumeInfo TrunkVolume { get; set; }

        public CargoInfo Cargo { get; set; }
    }
}
