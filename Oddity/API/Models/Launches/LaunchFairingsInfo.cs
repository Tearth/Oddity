using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launches
{
    public class LaunchFairingsInfo
    {
        public bool? Reused { get; set; }

        [JsonProperty("recovery_attempt")]
        public bool? RecoveryAttempt { get; set; }

        public bool? Recovered { get; set; }

        [JsonProperty("ships")]
        public List<string> ShipsId { get; set; }
    }
}
