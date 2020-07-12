using Newtonsoft.Json;

namespace Oddity.API.Models.Rockets
{
    public class IspInfo : ModelBase
    {
        public uint? Vacuum { get; set; }

        [JsonProperty("sea_level")]
        public uint? SeaLevel { get; set; }
    }
}
