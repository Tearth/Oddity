using Newtonsoft.Json;
using Oddity.Models.Common;

namespace Oddity.Models.Dragon
{
    public class DragonTrunkInfo : ModelBase
    {
        public DragonCargoInfo Cargo { get; set; }

        [JsonProperty("trunk_volume")]
        public VolumeInfo TrunkVolume { get; set; }
    }
}
