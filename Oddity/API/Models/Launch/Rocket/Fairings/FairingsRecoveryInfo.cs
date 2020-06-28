using Newtonsoft.Json;

namespace Oddity.API.Models.Launch.Rocket.Fairings
{
    public class FairingsRecoveryInfo
    {
        public bool? Reused { get; set; }

        [JsonProperty("recovery_attempt")]
        public bool? RecoveryAttempt { get; set; }

        public bool? Recovered { get; set; }
        public string Ship { get; set; }
    }
}
