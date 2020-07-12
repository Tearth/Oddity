using System;
using Newtonsoft.Json;
using Oddity.API.Models.Cores;
using Oddity.API.Models.Landpads;

namespace Oddity.API.Models.Launches
{
    public class LaunchCoreInfo : ModelBase
    {
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

        [JsonProperty("core")]
        public string CoreId
        {
            get => _coreId;
            set
            {
                _coreId = value;
                Core = new Lazy<CoreInfo>(() => Context.CoresEndpoint.Get(_coreId).Execute());
            }
        }

        [JsonProperty("landpad")]
        public string LandpadId
        {
            get => _landpadId;
            set
            {
                _landpadId = value;
                Landpad = new Lazy<LandpadInfo>(() => Context.LandpadsEndpoint.Get(_landpadId).Execute());
            }
        }

        public Lazy<CoreInfo> Core { get; private set; }
        public Lazy<LandpadInfo> Landpad { get; private set; }

        private string _coreId;
        private string _landpadId;
    }
}
