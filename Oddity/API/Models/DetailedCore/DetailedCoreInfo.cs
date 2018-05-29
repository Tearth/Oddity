using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Oddity.API.Models.DetailedCore
{
    public class DetailedCoreInfo
    {
        [JsonProperty("core_serial")]
        public string CoreSerial { get; set; }

        public int? Block { get; set; }
        public DetailedCoreStatus? Status { get; set; }

        [JsonProperty("original_launch")]
        public string OriginalLaunch { get; set; }

        public List<string> Missions { get; set; }

        [JsonProperty("rtls_attempt")]
        public bool? RtlcAttempt { get; set; }

        [JsonProperty("rtls_landings")]
        public int? RtlcLandings { get; set; }

        [JsonProperty("asds_attempt")]
        public bool? AsdsAttempt { get; set; }

        [JsonProperty("asds_landings")]
        public int? AsdsLandings { get; set; }

        [JsonProperty("water_landing")]
        public bool? WaterLanding { get; set; }

        public string Details { get; set; }
    }
}
