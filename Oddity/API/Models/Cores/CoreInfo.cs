using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oddity.API.Models.Launches;

namespace Oddity.API.Models.Cores
{
    public class CoreInfo : ModelBase
    {
        public string Id { get; set; }
        public string Serial { get; set; }
        public uint? Block { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public CoreStatus Status { get; set; }

        [JsonProperty("reuse_count")]
        public uint? ReuseCount { get; set; }

        [JsonProperty("rtls_attempts")]
        public uint? RtlsAttempts { get; set; }

        [JsonProperty("rtls_landings")]
        public uint? RtlsLandings { get; set; }

        [JsonProperty("asds_attempts")]
        public uint? AsdsAttempts { get; set; }

        [JsonProperty("asds_landings")]
        public uint? AsdsLandings { get; set; }

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
