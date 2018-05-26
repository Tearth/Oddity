using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Oddity.API.Models.Rocket;

namespace Oddity.API.Models.Launch.Rocket
{
    public class RocketInfo
    {
        [JsonProperty("rocket_id")]
        public RocketId Id { get; set; }

        [JsonProperty("rocket_name")]
        public string RocketName { get; set; }

        [JsonProperty("rocket_type")]
        public string RocketType { get; set; }

        [JsonProperty("first_stage")]
        public FirstStageInfo FirstStage { get; set; }

        [JsonProperty("second_stage")]
        public SecondStageInfo SecondStage { get; set; }
    }
}
