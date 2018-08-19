using Newtonsoft.Json;
using Oddity.API.Models.Common;
using Oddity.API.Models.Rocket.Stages.Payloads;

namespace Oddity.API.Models.Rocket.Stages
{
    public class SecondStageInfo
    {
        public uint? Engines { get; set; }

        [JsonProperty("fuel_amount_tons")]
        public uint? FuelAmountTons { get; set; }

        [JsonProperty("burn_time_sec")]
        public uint? BurnTimeSeconds { get; set; }

        public ThrustInfo Thrust { get; set; }
        public PayloadInfo Payloads { get; set; }
    }
}
