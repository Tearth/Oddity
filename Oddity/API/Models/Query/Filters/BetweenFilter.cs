using Newtonsoft.Json;

namespace Oddity.API.Models.Query.Filters
{
    public class BetweenFilter<T>
    {
        [JsonProperty("$gt")]
        public T From { get; set; }

        [JsonProperty("$lt")]
        public T To { get; set; }

        public BetweenFilter(T from, T to)
        {
            From = from;
            To = to;
        }
    }
}
