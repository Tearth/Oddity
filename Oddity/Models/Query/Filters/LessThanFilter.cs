using Newtonsoft.Json;

namespace Oddity.Models.Query.Filters
{
    public class LessThanFilter<TData>
    {
        [JsonProperty("$lt")]
        public TData LessThanValue { get; set; }

        public LessThanFilter(TData lessThanValue)
        {
            LessThanValue = lessThanValue;
        }
    }
}