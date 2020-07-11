using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launches
{
    public class LaunchInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("date_utc")]
        public DateTime? DateUtc { get; set; }

        [JsonProperty("date_unix")]
        public ulong? DateUnix { get; set; }

        [JsonProperty("date_local")]
        public DateTime? DateLocal { get; set; }

        [JsonProperty("date_precision")]
        public DatePrecision? DatePrecision { get; set; }

        public bool? Upcoming { get; set; }

        [JsonProperty("static_fire_date_utc")]
        public DateTime? StaticFireDateUtc { get; set; }

        [JsonProperty("static_fire_date_unix")]
        public ulong? StaticFireDateUnix { get; set; }

        [JsonProperty("tbd")]
        public bool? ToBeDated { get; set; }

        [JsonProperty("net")]
        public bool? NotEarlierThan { get; set; }

        [JsonProperty("window")]
        public ulong? Window { get; set; }

        [JsonProperty("rocket")]
        public string RocketId { get; set; }

        public bool? Success { get; set; }

        public List<string> Failures { get; set; }
        public string Details { get; set; }

        [JsonProperty("crew")]
        public List<string> CrewId { get; set; }

        [JsonProperty("ships")]
        public List<string> ShipsId { get; set; }

        [JsonProperty("capsules")]
        public List<string> CapsulesId { get; set; }

        [JsonProperty("payloads")]
        public List<string> PayloadsId { get; set; }

        [JsonProperty("launchpad")]
        public string LaunchpadId { get; set; }

        [JsonProperty("auto_update")]
        public bool? AutoUpdate { get; set; }

        public List<LaunchCoreInfo> Cores { get; set; }
        public LaunchLinks Links { get; set; }
        public LaunchFairingsInfo Fairings { get; set; }
    }
}
