using Newtonsoft.Json;

namespace Oddity.API.Models.Rockets
{
    public class PotentialPayloadInfo
    {
        [JsonProperty("composite_fairing")]
        public FairingInfo Fairing { get; set; }

        [JsonProperty("option_1")]
        public string Option { get; set; }
    }
}
