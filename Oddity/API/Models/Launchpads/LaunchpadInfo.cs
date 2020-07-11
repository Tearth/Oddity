using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launchpads
{
    public class LaunchpadInfo
    {
        public string Id { get; set; }
        public LaunchpadStatus? Status { get; set; }
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        public string Locality { get; set; }
        public string Region { get; set; }
        public string TimeZone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [JsonProperty("launch_attempts")]
        public uint? LaunchAttempts { get; set; }

        [JsonProperty("launch_successes")]
        public uint? LaunchSuccesses { get; set; }

        [JsonProperty("rockets")]
        public List<string> RocketsId { get; set; }

        [JsonProperty("launches")]
        public List<string> LaunchesId { get; set; }
    }
}
