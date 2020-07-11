using Newtonsoft.Json;

namespace Oddity.API.Models.Landpads
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
