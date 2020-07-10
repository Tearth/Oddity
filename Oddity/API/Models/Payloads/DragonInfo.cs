using Newtonsoft.Json;

namespace Oddity.API.Models.Payloads
{
    public class DragonInfo
    {
        [JsonProperty("capsule")]
        public string CapsuleId { get; set; }

        [JsonProperty("mass_returned_kg")]
        public double? MassReturnedKilograms { get; set; }

        [JsonProperty("mass_returned_lbs")]
        public double? MassReturnedPounds { get; set; }

        [JsonProperty("flight_time_sec")]
        public uint? FlightTimeSeconds { get; set; }

        public string Manifest { get; set; }

        [JsonProperty("water_landing")]
        public bool? WaterLanding { get; set; }

        [JsonProperty("land_landing")]
        public bool? LandLanding { get; set; }
    }
}
