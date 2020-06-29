using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launchpad
{
    public class LaunchpadInfo
    {
        public LaunchpadId? Id { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        public LaunchpadStatus? Status { get; set; }
        public LaunchpadLocation Location { get; set; }

        [JsonProperty("vehicles_launched")]
        public List<string> VehiclesLaunched { get; set; }

        public string Details { get; set; }
    }
}
