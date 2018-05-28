using Newtonsoft.Json;

namespace Oddity.API.Models.Common
{
    public class VolumeInfo
    {
        [JsonProperty("cubic_meters")]
        public float? CubicMeters { get; set; }

        [JsonProperty("cubic_feet")]
        public float? CubicFeet { get; set; }
    }
}
