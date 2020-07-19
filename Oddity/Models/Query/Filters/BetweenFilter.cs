using Newtonsoft.Json;

namespace Oddity.Models.Query.Filters
{
    public class BetweenFilter<TData>
    {
        [JsonProperty("$gt")]
        public TData From { get; set; }

        [JsonProperty("$lt")]
        public TData To { get; set; }

        public BetweenFilter(TData from, TData to)
        {
            From = from;
            To = to;
        }
    }
}
