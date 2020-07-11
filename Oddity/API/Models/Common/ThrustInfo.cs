﻿using Newtonsoft.Json;

namespace Oddity.API.Models.Common
{
    public class ThrustInfo
    {
        [JsonProperty("kN")]
        public double? Kilonewtons { get; set; }

        [JsonProperty("lbf")]
        public double? PoundForce { get; set; }
    }
}