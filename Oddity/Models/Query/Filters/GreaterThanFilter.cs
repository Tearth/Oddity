using Newtonsoft.Json;

namespace Oddity.Models.Query.Filters
{
    public class GreaterThanFilter<T>
    {
        [JsonProperty("$gt")]
        public T GreaterThanValue { get; set; }

        public GreaterThanFilter(T greaterThanValue)
        {
            GreaterThanValue = greaterThanValue;
        }
    }
}