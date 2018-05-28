using Newtonsoft.Json;

namespace Oddity.API.Models.Launch
{
    public class ReuseInfo
    {
        public bool? Core { get; set; }

        [JsonProperty("side_core1")]
        public bool? FirstSideCore { get; set; }

        [JsonProperty("side_core2")]
        public bool? SecondSideCore { get; set; }

        public bool? Fairings { get; set; }
        public bool? Capsule { get; set; }
    }
}
