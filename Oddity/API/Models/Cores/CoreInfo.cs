using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Cores
{
    public class CoreInfo
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
        public List<string> LaunchesId { get; set; }

        public string Serial { get; set; }
        public CoreStatus? Status { get; set; }
    }
}
