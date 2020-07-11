using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Crew
{
    public class CrewInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Agency { get; set; }
        public string Wikipedia { get; set; }
        public string Image { get; set; }

        [JsonProperty("launches")]
        public List<string> LaunchesId { get; set; }

        public CrewStatus? Status { get; set; }
    }
}
