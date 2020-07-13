using Newtonsoft.Json;
using Oddity.Models.Common;

namespace Oddity.Models.Rockets
{
    public class SecondStageInfo : ModelBase
    {
        public bool? Reusable { get; set; }
        public uint? Engines { get; set; }

        public ThrustInfo Thrust { get; set; }
        public PotentialPayloadInfo Payloads { get; set; }

        [JsonProperty("fuel_amount_tons")]
        public uint? FuelAmountTons { get; set; }

        [JsonProperty("burn_time_sec")]
        public uint? BurnTimeSeconds { get; set; }
    }
}
