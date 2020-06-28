using Newtonsoft.Json;

namespace Oddity.API.Models.Company
{
    public class CompanyLinks
    {
        public string Website { get; set; }
        public string Flickr { get; set; }
        public string Twitter { get; set; }

        [JsonProperty("elon_twitter")]
        public string ElonTwitter { get; set; }
    }
}
