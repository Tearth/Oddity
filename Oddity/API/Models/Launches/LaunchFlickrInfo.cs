using System.Collections.Generic;

namespace Oddity.API.Models.Launches
{
    public class LaunchFlickrInfo : ModelBase
    {
        public List<string> Small { get; set; }
        public List<string> Original { get; set; }
    }
}
