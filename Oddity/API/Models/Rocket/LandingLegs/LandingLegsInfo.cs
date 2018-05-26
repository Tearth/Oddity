namespace Oddity.API.Models.Rocket.LandingLegs
{
    public class LandingLegsInfo
    {
        [JsonProperty("Number")]
        public int Count { get; set; }

        public string Material { get; set; }
    }
}
