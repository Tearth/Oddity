using System;
using Newtonsoft.Json;
using Oddity.API.Models.Capsules;
using Oddity.API.Models.Launches;

namespace Oddity.API.Models.Payloads
{
    public class DragonInfo : ModelBase
    {
        public string Manifest { get; set; }

        [JsonProperty("mass_returned_kg")]
        public double? MassReturnedKilograms { get; set; }

        [JsonProperty("mass_returned_lbs")]
        public double? MassReturnedPounds { get; set; }

        [JsonProperty("flight_time_sec")]
        public uint? FlightTimeSeconds { get; set; }

        [JsonProperty("water_landing")]
        public bool? WaterLanding { get; set; }

        [JsonProperty("land_landing")]
        public bool? LandLanding { get; set; }

        [JsonProperty("capsule")]
        public string CapsuleId
        {
            get => _capsuleId;
            set
            {
                _capsuleId = value;
                Capsule = new Lazy<CapsuleInfo>(() => Context.CapsulesEndpoint.Get(_capsuleId).Execute());
            }
        }

        public Lazy<CapsuleInfo> Capsule { get; private set; }

        private string _capsuleId;
    }
}
