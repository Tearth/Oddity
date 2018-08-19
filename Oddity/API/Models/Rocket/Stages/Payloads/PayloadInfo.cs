using Newtonsoft.Json;

namespace Oddity.API.Models.Rocket.Stages.Payloads
{
    public class PayloadInfo
    {
        [JsonProperty("composite_fairing")]
        public FairingInfo Fairing { get; set; }
    }
}
