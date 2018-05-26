using Newtonsoft.Json;

namespace Oddity.API.Models.Rocket.PayloadWeights
{
    public class PayloadWeightInfo
    {
        [JsonProperty("id")]
        public PayloadType Type { get; set; }

        public string Name { get; set; }

        [JsonProperty("kg")]
        public int Kilograms { get; set; }

        [JsonProperty("lb")]
        public int Pounds { get; set; }
    }
}
