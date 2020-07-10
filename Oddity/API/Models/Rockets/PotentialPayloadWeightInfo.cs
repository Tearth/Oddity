using Newtonsoft.Json;

namespace Oddity.API.Models.Rockets
{
    public class PotentialPayloadWeightInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("kg")]
        public double? Kilograms { get; set; }

        [JsonProperty("lb")]
        public double? Pounds { get; set; }
    }
}
