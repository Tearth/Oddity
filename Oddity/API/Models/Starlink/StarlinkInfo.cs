using Newtonsoft.Json;

namespace Oddity.API.Models.Starlink
{
    public class StarlinkInfo
    {
        public string Id { get; set; }
        public string Version { get; set; }

        [JsonProperty("launch")]
        public string LaunchId { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("height_km")]
        public double? HeightKilometers { get; set; }

        [JsonProperty("velocity_kms")]
        public double? VelocityKilometersPerSecond { get; set; }

        public SpaceTrackInfo SpaceTrack { get; set; }
    }
}
