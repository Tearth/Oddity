using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launchpad
{
    public class LaunchpadInfo
    {
        public int? Id { get; set; }

        [JsonProperty("site_id")]
        public LaunchpadId? SiteId { get; set; }

        public LaunchpadStatus? Status { get; set; }
        public LaunchpadLocation Location { get; set; }

        [JsonProperty("vehicles_launched")]
        public List<string> VehiclesLaunched { get; set; }

        [JsonProperty("attempted_launches")]
        public int? AttemptedLaunches { get; set; }

        [JsonProperty("successful_launches")]
        public int? SuccessfulLaunches { get; set; }

        public string Wikipedia { get; set; }
        public string Details { get; set; }

        [JsonProperty("site_name_long")]
        public string FullName { get; set; }

    }
}
