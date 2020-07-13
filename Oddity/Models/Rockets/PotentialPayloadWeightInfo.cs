using Newtonsoft.Json;

namespace Oddity.Models.Rockets
{
    public class PotentialPayloadWeightInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("kg")]
        public double? Kilograms { get; set; }

        [JsonProperty("lb")]
        public double? Pounds { get; set; }
    }
}
