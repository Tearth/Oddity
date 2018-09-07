using Newtonsoft.Json;
using Oddity.API.Models.Common;

namespace Oddity.API.Models.Rocket.Stages
{
    public class FirstStageInfo
    {
        public bool Reusable { get; set; }
        public int Engines { get; set; }

        [JsonProperty("fuel_amount_tons")]
        public float FuelAmountTons { get; set; }

        [JsonProperty("burn_time_sec")]
        public int BurnTimeSeconds { get; set; }

        [JsonProperty("thrust_sea_level")]
        public ThrustInfo ThrustSeaLevel { get; set; }

        [JsonProperty("thrust_vacuum")]
        public ThrustInfo ThrustVacuum { get; set; }
    }
}
