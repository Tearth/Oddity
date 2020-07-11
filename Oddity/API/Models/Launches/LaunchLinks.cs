using Newtonsoft.Json;

namespace Oddity.API.Models.Launches
{
    public class LaunchLinks
    {
        public LaunchPatchInfo Patch { get; set; }
        public LaunchRedditInfo Reddit { get; set; }
        public LaunchFlickrInfo Flickr { get; set; }
        public string Presskit { get; set; }
        public string Webcast { get; set; }

        [JsonProperty("youtube_id")]
        public string YouTubeId { get; set; }
        public string Article { get; set; }
        public string Wikipedia { get; set; }
    }
}
