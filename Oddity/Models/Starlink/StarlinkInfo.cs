using System;
using Newtonsoft.Json;
using Oddity.Models.Launches;

namespace Oddity.Models.Starlink
{
    public class StarlinkInfo : ModelBase
    {
        public string Id { get; set; }
        public string Version { get; set; }

        [JsonProperty("spaceTrack")]
        public SpaceTrackInfo SpaceTrack { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("height_km")]
        public double? HeightKilometers { get; set; }

        [JsonProperty("velocity_kms")]
        public double? VelocityKilometersPerSecond { get; set; }

        [JsonProperty("launch")]
        public string LaunchId 
        { 
            get => _launchId;
            set
            {
                _launchId = value;
                Launch = new Lazy<LaunchInfo>(() => Context.LaunchesEndpoint.Get(_launchId).Execute());
            }
        }

        public Lazy<LaunchInfo> Launch { get; private set; }

        private string _launchId;

        public override string ToString()
        {
            return SpaceTrack.ObjectName;
        }
    }
}
