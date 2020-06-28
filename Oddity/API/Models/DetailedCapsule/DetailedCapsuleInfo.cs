using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oddity.API.Models.Capsule;

namespace Oddity.API.Models.DetailedCapsule
{
    public class DetailedCapsuleInfo
    {
        [JsonProperty("capsule_serial")]
        public string CapsuleSerial { get; set; }

        [JsonProperty("capsule_id")]
        public DraognId? CapsuleId { get; set; }

        public DetailedCapsuleStatus? Status { get; set; }

        [JsonProperty("original_launch")]
        public DateTime? OriginalLaunch { get; set; }

        [JsonProperty("original_launch_unix")]
        public ulong? OriginalLaunchUnix { get; set; }

        public List<CapsuleMissionInfo> Missions { get; set; }
        public uint? Landings { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
    }
}
