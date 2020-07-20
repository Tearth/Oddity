using Newtonsoft.Json;

namespace Oddity.Models.Dragon
{
    public class DragonHeatshieldInfo : ModelBase
    {
        public string Material { get; set; }

        [JsonProperty("size_meters")]
        public double? SizeMeters { get; set; }

        [JsonProperty("temp_degrees")]
        public uint? TemperatureDegrees { get; set; }

        [JsonProperty("dev_partner")]
        public string DevPartner { get; set; }
    }
}
