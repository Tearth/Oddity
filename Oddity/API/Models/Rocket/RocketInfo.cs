using System;
using System.Collections.Generic;
using Oddity.API.Models.Common;
using Oddity.API.Models.Rocket.Engines;
using Oddity.API.Models.Rocket.LandingLegs;
using Oddity.API.Models.Rocket.PayloadWeights;

namespace Oddity.API.Models.Rocket
{
    public class RocketInfo
    {
        public RocketId Id { get; set; }

        public string Name { get; set; }
        public bool Active { get; set; }

        public int Stages { get; set; }
        public int Boosters { get; set; }

        [JsonProperty("cost_per_launch")]
        public uint CostPerLaunch { get; set; }

        [JsonProperty("success_rate_pct")]
        public int SuccessRate { get; set; }

        [JsonProperty("first_flight")]
        public DateTime FirstFlight { get; set; }

        public string Country { get; set; }
        public string Company { get; set; }
        public SizeInfo Height { get; set; }
        public SizeInfo Diameter { get; set; }
        public RocketMass Mass { get; set; }

        [JsonProperty("payload_weights")]
        public List<PayloadWeightInfo> PayloadWeights { get; set; }

        public EnginesInfo Engines { get; set; }

        [JsonProperty("landing_legs")]
        public LandingLegsInfo LandingLegs { get; set; }

        public string Description { get; set; }
    }
}
