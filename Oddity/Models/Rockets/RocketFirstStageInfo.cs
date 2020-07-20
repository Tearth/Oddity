using Newtonsoft.Json;
using Oddity.Models.Common;

namespace Oddity.Models.Rockets
{
    public class RocketFirstStageInfo : ModelBase
    {
        public bool? Reusable { get; set; }
        public uint? Engines { get; set; }

        [JsonProperty("thrust_sea_level")]
        public ThrustInfo ThrustSeaLevel { get; set; }

        [JsonProperty("thrust_vacuum")]
        public ThrustInfo ThrustVacuum { get; set; }

        [JsonProperty("fuel_amount_tons")]
        public uint? FuelAmountTons { get; set; }

        [JsonProperty("burn_time_sec")]
        public uint? BurnTimeSeconds { get; set; }
    }
}
