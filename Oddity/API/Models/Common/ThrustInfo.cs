using Newtonsoft.Json;

namespace Oddity.API.Models.Common
{
    public class ThrustInfo
    {
        [JsonProperty("kn")]
        public double? Kilonewtons { get; set; }

        [JsonProperty("lbf")]
        public double? PoundsForce { get; set; }
    }
}
