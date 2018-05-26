using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launch.Rocket
{
    public class ReuseInfo
    {
        public bool Core { get; set; }

        [JsonProperty("side_core1")]
        public bool SideCore1 { get; set; }

        [JsonProperty("side_core2")]
        public bool SideCore2 { get; set; }

        public bool Fairings { get; set; }
        public bool Capsule { get; set; }
    }
}
