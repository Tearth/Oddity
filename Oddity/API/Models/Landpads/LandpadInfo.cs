using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oddity.API.Models.Launches;

namespace Oddity.API.Models.Landpads
{
    public class LandpadInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        public LandpadStatus? Status { get; set; }
        public string Type { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        
        [JsonProperty("landing_attempts")]
        public uint? LandingAttempts { get; set; }

        [JsonProperty("landing_successes")]
        public uint? LandingSuccesses { get; set; }

        public string Wikipedia { get; set; }
        public string Details { get; set; }

        [JsonProperty("launches")]
        public List<string> LaunchesId
        {
            get => _launchesId;
            set
            {
                _launchesId = value;

                Launches = new List<Lazy<LaunchInfo>>();
                for (var i = 0; i < _launchesId.Count; i++)
                {
                    var index = i;
                    Launches.Add(new Lazy<LaunchInfo>(() => Context.LaunchesEndpoint.Get(_launchesId[index]).Execute()));
                }
            }
        }

        public List<Lazy<LaunchInfo>> Launches { get; set; }

        private List<string> _launchesId;
    }
}
