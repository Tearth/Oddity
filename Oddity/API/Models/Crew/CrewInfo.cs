using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oddity.API.Models.Launches;

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
        public List<string> LaunchesId
        {
            get => _launchesId;
            set
            {
                _launchesId = value;
                Launches = _launchesId.Select(p => new Lazy<LaunchInfo>(() => Context.LaunchesEndpoint.Get(p).Execute())).ToList();
            }
        }

        public List<Lazy<LaunchInfo>> Launches { get; private set; }
        private List<string> _launchesId;

        public CrewStatus? Status { get; set; }
    }
}
