using Newtonsoft.Json;

namespace Oddity.Models.Rockets
{
    public class PotentialPayloadInfo : ModelBase
    {
        [JsonProperty("composite_fairing")]
        public FairingInfo Fairing { get; set; }

        [JsonProperty("option_1")]
        public string Option { get; set; }
    }
}
