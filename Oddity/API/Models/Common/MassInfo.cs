using Newtonsoft.Json;

namespace Oddity.API.Models.Common
{
    public class MassInfo
    {
        [JsonProperty("kg")]
        public float? Kilograms { get; set; }

        [JsonProperty("lb")]
        public float? Pounds { get; set; }
    }
}
