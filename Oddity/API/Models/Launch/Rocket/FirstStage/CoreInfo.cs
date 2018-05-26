using Newtonsoft.Json;

namespace Oddity.API.Models.Launch.Rocket.FirstStage
{
    public class CoreInfo
    {
        [JsonProperty("core_serial")]
        public string CoreSerial { get; set; }

        public int Flight { get; set; }
        public int? Block { get; set; }
        public bool Reused { get; set; }

        [JsonProperty("land_success")]
        public bool? LandSuccess { get; set; }

        [JsonProperty("landing_type")]
        public LandingType? LandingType { get; set; }

        [JsonProperty("landing_vehicle")]
        public LandingVehicleType? LandingVehicle { get; set; }
    }
}
