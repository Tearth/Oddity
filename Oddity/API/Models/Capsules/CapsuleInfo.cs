using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Capsules
{
    public class CapsuleInfo
    {
        public string Id { get; set; }
        public string Serial { get; set; }
        public string Status { get; set; }

        [JsonProperty("reuse_count")]
        public uint? ReuseCount { get; set; }

        [JsonProperty("water_landings")]
        public uint? WaterLandings { get; set; }

        [JsonProperty("land_landings")]
        public uint? LandLandings { get; set; }

        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }

        [JsonProperty("launches")]
        public List<string> LaunchesId { get; set; }
    }
}
