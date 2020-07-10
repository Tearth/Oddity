using Newtonsoft.Json;

namespace Oddity.API.Models.Common
{
    public class MassInfo
    {
        [JsonProperty("kg")]
        public double? Kilograms { get; set; }

        [JsonProperty("lb")]
        public double? Pounds { get; set; }
    }
}
