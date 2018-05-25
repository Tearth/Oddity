using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Oddity.API.Models.Rocket.Payload
{
    public class PayloadWeightInfo
    {
        [JsonProperty("id")]
        public PayloadType Type { get; set; }

        public string Name { get; set; }
        public int Kg { get; set; }
        public int Lb { get; set; }
    }
}
