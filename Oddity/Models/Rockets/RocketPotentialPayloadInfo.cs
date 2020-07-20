using Newtonsoft.Json;

namespace Oddity.Models.Rockets
{
    public class RocketPotentialPayloadInfo : ModelBase
    {
        [JsonProperty("composite_fairing")]
        public RocketFairingInfo Fairing { get; set; }

        [JsonProperty("option_1")]
        public string Option { get; set; }
    }
}
