using Newtonsoft.Json;

namespace Oddity.API.Models.Rocket.LandingLegs
{
    public class LandingLegsInfo
    {
        [JsonProperty("Number")]
        public uint? Count { get; set; }

        public string Material { get; set; }
    }
}
