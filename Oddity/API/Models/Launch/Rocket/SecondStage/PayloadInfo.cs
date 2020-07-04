using System.Collections.Generic;
using Newtonsoft.Json;
using Oddity.API.Models.Launch.Rocket.SecondStage.Orbit;

namespace Oddity.API.Models.Launch.Rocket.SecondStage
{
    public class PayloadInfo
    {
        [JsonProperty("payload_id")]
        public string PayloadId { get; set; }

        [JsonProperty("norad_id")]
        public List<string> NoradId { get; set; }

        public bool? Reused { get; set; }
        public List<string> Customers { get; set; }
        public string Nationality { get; set; }
        public string Manufacturer { get; set; }

        [JsonProperty("payload_type")]
        public string PayloadType { get; set; }

        [JsonProperty("payload_mass_kg")]
        public double? PayloadMassKilograms { get; set; }

        [JsonProperty("payload_mass_lbs")]
        public double? PayloadMassPounds { get; set; }

        public OrbitType? Orbit { get; set; }

        [JsonProperty("orbit_params")]
        public OrbitParameters OrbitParameters { get; set; }
    }
}
