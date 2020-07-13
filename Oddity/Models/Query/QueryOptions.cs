using Newtonsoft.Json;

namespace Oddity.Models.Query
{
    public class QueryOptions
    {
        [JsonProperty("sort", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Sort { get; set; }

        [JsonProperty("offset", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public uint? Offset { get; set; }

        [JsonProperty("page", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public uint? Page { get; set; }

        [JsonProperty("limit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public uint? Limit { get; set; }
    }
}
