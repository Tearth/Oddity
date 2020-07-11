using Newtonsoft.Json;

namespace Oddity.API.Models.Landspads
{
    public enum LandpadStatus
    {
        Unknown,
        Active,
        Inactive,
        Retired,
        Lost,

        [JsonProperty("under construction")]
        UnderConstruction
    }
}
