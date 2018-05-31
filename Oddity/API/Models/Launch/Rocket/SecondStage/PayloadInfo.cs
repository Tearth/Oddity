using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launch.Rocket.SecondStage
{
    public class PayloadInfo
    {
        [JsonProperty("payload_id")]
        public string PayloadId { get; set; }

        public bool? Reused { get; set; }
        public List<string> Customers { get; set; }

        [JsonProperty("payload_type")]
        public string PayloadType { get; set; }

        [JsonProperty("payload_mass_kg")]
        public float? PayloadMassKilograms { get; set; }

        [JsonProperty("payload_mass_lbs")]
        public float? PayloadMassPounds { get; set; }

        public OrbitType? Orbit { get; set; }
    }
}
