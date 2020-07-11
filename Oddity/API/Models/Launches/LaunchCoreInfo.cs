using Newtonsoft.Json;

namespace Oddity.API.Models.Launches
{
    public class LaunchCoreInfo
    {
        [JsonProperty("core")]
        public string CoreId { get; set; }

        public uint? Flight { get; set; }
        public bool? Gridfins { get; set; }
        public bool? Legs { get; set; }
        public bool? Reused { get; set; }

        [JsonProperty("landing_attempt")]
        public bool? LandingAttempt { get; set; }

        [JsonProperty("landing_success")]
        public bool? LandingSuccess { get; set; }

        [JsonProperty("landing_type")]
        public string LandingType { get; set; }

        [JsonProperty("landpad")]
        public string LandpadId { get; set; }
    }
}
