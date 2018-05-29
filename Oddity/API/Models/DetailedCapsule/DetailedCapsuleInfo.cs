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
        public CapsuleId? CapsuleId { get; set; }

        public DetailedCapsuleStatus? Status { get; set; }

        [JsonProperty("original_launch")]
        public string OriginalLaunch { get; set; }

        public List<string> Missions { get; set; }
        public int? Landings { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
    }
}
