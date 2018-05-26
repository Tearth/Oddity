using Newtonsoft.Json;

namespace Oddity.API.Models.Rocket.Stages.Payloads
{
    public class PayloadInfo
    {
        [JsonProperty("composite_fairings")]
        public FairingInfo Fairing { get; set; }
    }
}
