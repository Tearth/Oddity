using System;
using Newtonsoft.Json;
using Oddity.API.Models.Launch.Rocket;

namespace Oddity.API.Models.Launch
{
    public class LaunchInfo
    {
        [JsonProperty("flight_number")]
        public uint? FlightNumber { get; set; }

        [JsonProperty("mission_name")]
        public string MissionName { get; set; }

        public bool? Upcoming { get; set; }

        [JsonProperty("launch_year")]
        public uint? LaunchYear { get; set; }

        [JsonProperty("launch_date_unix")]
        public ulong? LaunchDateUnix { get; set; }

        [JsonProperty("launch_date_utc")]
        public DateTime? LaunchDateUtc { get; set; }

        [JsonProperty("launch_date_local")]
        public DateTime? LaunchDateLocal { get; set; }

        [JsonProperty("is_tentative")]
        public bool IsTentative { get; set; }

        [JsonProperty("tentative_max_precision")]
        public TentativeMaxPrecision? TentativeMaxPrecision { get; set; }

        public RocketInfo Rocket { get; set; }
        public ReuseInfo Reuse { get; set; }
        public TelemetryInfo Telemetry { get; set; }

        [JsonProperty("launch_site")]
        public LaunchSiteInfo LaunchSite { get; set; }

        [JsonProperty("launch_success")]
        public bool? LaunchSuccess { get; set; }

        public LinksInfo Links { get; set; }
        public string Details { get; set; }

        [JsonProperty("static_fire_date_utc")]
        public DateTime? StaticFireDateUtc { get; set; }
    }
}
