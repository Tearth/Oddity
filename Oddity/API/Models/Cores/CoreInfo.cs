using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oddity.API.Models.Launches;

namespace Oddity.API.Models.Cores
{
    public class CoreInfo : ModelBase
    {
        public string Id { get; set; }
        public uint? Block { get; set; }

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

                Launches = new List<Lazy<LaunchInfo>>();
                for (var i = 0; i < _launchesId.Count; i++)
                {
                    var index = i;
                    Launches.Add(new Lazy<LaunchInfo>(() => Context.LaunchesEndpoint.Get(_launchesId[index]).Execute()));
                }
            }
        }

        public List<Lazy<LaunchInfo>> Launches { get; set; }

        public string Serial { get; set; }
        public CoreStatus? Status { get; set; }

        private List<string> _launchesId;
    }
}
