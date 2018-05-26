using Oddity.API.Models.Common;

namespace Oddity.API.Models.Rocket.Engines
{
    public class EnginesInfo
    {
        public int Number { get; set; }
        public EngineType Type { get; set; }
        public string Version { get; set; }
        public string Layout { get; set; }

        [JsonProperty("engine_loss_max")]
        public int EngineLossMax { get; set; }

        [JsonProperty("propellant_1")]
        public string FirstPropellant { get; set; }

        [JsonProperty("propellant_2")]
        public string SecondPropellant { get; set; }

        [JsonProperty("thrust_sea_level")]
        public ThrustInfo ThrustSeaLevel { get; set; }

        [JsonProperty("thrust_vacuum")]
        public ThrustInfo ThrustVacuum { get; set; }

        [JsonProperty("thrust_to_weight")]
        public float ThrustToWeight { get; set; }
    }
}
