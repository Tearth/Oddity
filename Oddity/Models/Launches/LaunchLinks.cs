using Newtonsoft.Json;

namespace Oddity.Models.Launches
{
    public class LaunchLinks : ModelBase
    {
        public string Presskit { get; set; }
        public string Webcast { get; set; }
        public string Article { get; set; }
        public string Wikipedia { get; set; }

        public LaunchPatchInfo Patch { get; set; }
        public LaunchRedditInfo Reddit { get; set; }
        public LaunchFlickrInfo Flickr { get; set; }

        [JsonProperty("youtube_id")]
        public string YouTubeId { get; set; }
    }
}
