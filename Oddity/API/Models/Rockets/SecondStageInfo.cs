using Newtonsoft.Json;
using Oddity.API.Models.Common;

namespace Oddity.API.Models.Rockets
{
    public class SecondStageInfo
    {
        public ThrustInfo Thrust { get; set; }
        public PotentialPayloadInfo Payloads { get; set; }

        public bool? Reusable { get; set; }
        public uint? Engines { get; set; }

        [JsonProperty("fuel_amount_tons")]
        public uint? FuelAmountTons { get; set; }

        [JsonProperty("burn_time_sec")]
        public uint? BurnTimeSeconds { get; set; }
    }
}
