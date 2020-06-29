using Newtonsoft.Json;

namespace Oddity.API.Models.Common
{
    public class VolumeInfo
    {
        [JsonProperty("cubic_meters")]
        public double? CubicMeters { get; set; }

        [JsonProperty("cubic_feet")]
        public double? CubicFeet { get; set; }
    }
}
