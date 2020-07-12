using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oddity.API.Models.Launches;

namespace Oddity.API.Models.Landpads
{
    public class LandpadInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Wikipedia { get; set; }
        public string Details { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public LandpadStatus Status { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("landing_attempts")]
        public uint? LandingAttempts { get; set; }

        [JsonProperty("landing_successes")]
        public uint? LandingSuccesses { get; set; }

        [JsonProperty("launches")]
        public List<string> LaunchesId
        {
            get => _launchesId;
            set
            {
                _launchesId = value;
                Launches = _launchesId.Select(p => new Lazy<LaunchInfo>(() => Context.LaunchesEndpoint.Get(p).Execute())).ToList();
            }
        }

        public List<Lazy<LaunchInfo>> Launches { get; private set; }

        private List<string> _launchesId;
    }
}
