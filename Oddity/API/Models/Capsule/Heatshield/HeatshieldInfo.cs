namespace Oddity.API.Models.Capsule.Heatshield
{
    public class HeatshieldInfo
    {
        public string Material { get; set; }

        [JsonProperty("size_meters")]
        public float SizeMeters { get; set; }

        [JsonProperty("temp_degrees")]
        public int MaxTempDegrees { get; set; }

        [JsonProperty("dev_partner")]
        public string DevPartner { get; set; }
    }
}
