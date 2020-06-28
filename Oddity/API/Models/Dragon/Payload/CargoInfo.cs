using Newtonsoft.Json;

namespace Oddity.API.Models.Capsule.Payload
{
    public class CargoInfo
    {
        [JsonProperty("solar_array")]
        public uint? SolarArraysCount { get; set; }

        [JsonProperty("unpressurized_cargo")]
        public bool? UnpressurizedCargo { get; set; }
    }
}
