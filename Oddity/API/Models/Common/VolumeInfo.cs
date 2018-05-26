using Newtonsoft.Json;

namespace Oddity.API.Models.Common
{
    public class VolumeInfo
    {
        [JsonProperty("cubic_meters")]
        public int CubicMeters { get; set; }

        [JsonProperty("cubic_feet")]
        public int CubicFeet { get; set; }
    }
}
