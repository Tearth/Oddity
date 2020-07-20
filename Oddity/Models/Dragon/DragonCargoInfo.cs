using Newtonsoft.Json;

namespace Oddity.Models.Dragon
{
    public class DragonCargoInfo : ModelBase
    {
        [JsonProperty("solar_array")]
        public uint? SolarArray { get; set; }

        [JsonProperty("unpressurized_cargo")]
        public bool? UnpressurizedCargo { get; set; }
    }
}
