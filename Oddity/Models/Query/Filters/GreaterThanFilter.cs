using Newtonsoft.Json;

namespace Oddity.Models.Query.Filters
{
    public class GreaterThanFilter<TData>
    {
        [JsonProperty("$gt")]
        public TData GreaterThanValue { get; set; }

        public GreaterThanFilter(TData greaterThanValue)
        {
            GreaterThanValue = greaterThanValue;
        }
    }
}