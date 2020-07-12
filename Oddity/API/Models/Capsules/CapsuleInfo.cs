using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oddity.API.Models.Launches;

namespace Oddity.API.Models.Capsules
{
    public class CapsuleInfo : ModelBase
    {
        public string Id { get; set; }
        public string Serial { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public CapsuleStatus Status { get; set; }

        [JsonProperty("reuse_count")]
        public uint? ReuseCount { get; set; }

        [JsonProperty("water_landings")]
        public uint? WaterLandings { get; set; }

        [JsonProperty("land_landings")]
        public uint? LandLandings { get; set; }

        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }

        [JsonProperty("launches")]
        public List<string> LaunchesId
        {
            get => _launchesId;
            set
            {
                _launchesId = value;
                Launches = _launchesId.Select(p => new Lazy<LaunchInfo>(() => Context.LaunchesEndpoint.Get(p).Execute())).ToList();
            }
        }

        public List<Lazy<LaunchInfo>> Launches { get; private set; }

        private List<string> _launchesId;
    }
}
