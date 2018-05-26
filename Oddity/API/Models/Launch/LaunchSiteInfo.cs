using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Oddity.API.Models.Launchpad;

namespace Oddity.API.Models.Launch
{
    public class LaunchSiteInfo
    {
        [JsonProperty("site_id")]
        public LaunchpadId SiteId { get; set; }

        [JsonProperty("site_name")]
        public string SiteName { get; set; }

        [JsonProperty("site_name_long")]
        public string SiteLongName { get; set; }
    }
}
