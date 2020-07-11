using Newtonsoft.Json;

namespace Oddity.API.Models.Launchpads
{
    public enum LaunchpadStatus
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
