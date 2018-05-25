using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Oddity.API.Models.Capsule.Payload
{
    public class CargoInfo
    {
        [JsonProperty("solar_array")]
        public int SolarArrays { get; set; }

        [JsonProperty("unpressurized_cargo")]
        public bool UnpressurizedCargo { get; set; }
    }
}
