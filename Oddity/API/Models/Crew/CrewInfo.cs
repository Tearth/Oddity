using System;
using System.Collections.Generic;
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

                Launches = new List<Lazy<LaunchInfo>>();
                for (var i = 0; i < _launchesId.Count; i++)
                {
                    var index = i;
                    Launches.Add(new Lazy<LaunchInfo>(() => Context.LaunchesEndpoint.Get(_launchesId[index]).Execute()));
                }
            }
        }

        public List<Lazy<LaunchInfo>> Launches { get; set; }
        public CrewStatus? Status { get; set; }

        private List<string> _launchesId;
    }
}
