using Newtonsoft.Json;

namespace Oddity.API.Models.Launch
{
    public class LinksInfo
    {
        [JsonProperty("mission_patch")]
        public string MissionPatch { get; set; }

        [JsonProperty("mission_patch_small")]
        public string MissionPatchSmall { get; set; }

        [JsonProperty("reddit_campaign")]
        public string RedditCampaign { get; set; }

        [JsonProperty("reddit_launch")]
        public string RedditLaunch { get; set; }

        [JsonProperty("reddit_recovery")]
        public string RedditRecovery { get; set; }

        [JsonProperty("reddit_media")]
        public string RedditMedia { get; set; }

        public string Presskit { get; set; }

        [JsonProperty("article_link")]
        public string ArticleLink { get; set; }

        public string Wikipedia { get; set; }

        [JsonProperty("video_link")]
        public string VideoLink { get; set; }
    }
}
