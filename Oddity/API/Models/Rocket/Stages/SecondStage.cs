using Newtonsoft.Json;
using Oddity.API.Models.Rocket.Stages.Payloads;

namespace Oddity.API.Models.Rocket.Stages
{
    public class SecondStage
    {
        public int Engines { get; set; }

        [JsonProperty("fuel_amount_tons")]
        public int FuelAmountTons { get; set; }

        [JsonProperty("burn_time_sec")]
        public int BurnTimeSeconds { get; set; }

        public ThrustInfo Thrust { get; set; }
        public PayloadInfo Payloads { get; set; }
    }
}
