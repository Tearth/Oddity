using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.DetailedCore
{
    public class DetailedCoreInfo
    {
        [JsonProperty("core_serial")]
        public string CoreSerial { get; set; }

        public uint? Block { get; set; }
        public DetailedCoreStatus? Status { get; set; }

        [JsonProperty("original_launch")]
        public DateTime? OriginalLaunch { get; set; }

        [JsonProperty("original_launch_unix")]
        public ulong? OriginalLaunchUnix { get; set; }

        public List<CoreMissionInfo> Missions { get; set; }

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

        [JsonProperty("water_landing")]
        public bool? WaterLanding { get; set; }

        public string Details { get; set; }
    }
}
