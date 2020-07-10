using Newtonsoft.Json;

namespace Oddity.API.Models.Starlink
{
    public class StarlinkInfo
    {
        public string Id { get; set; }
        public string Version { get; set; }

        [JsonProperty("launch")]
        public string LaunchId { get; set; }

        public SpaceTrack SpaceTrack { get; set; }
    }
}
