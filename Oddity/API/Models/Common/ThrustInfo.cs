using Newtonsoft.Json;

namespace Oddity.API.Models.Common
{
    public class ThrustInfo
    {
        [JsonProperty("kn")]
        public float KiloNewtons { get; set; }

        [JsonProperty("lbf")]
        public float PoundsForce { get; set; }
    }
}
