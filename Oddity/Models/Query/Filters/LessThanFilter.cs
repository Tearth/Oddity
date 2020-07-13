using Newtonsoft.Json;

namespace Oddity.Models.Query.Filters
{
    public class LessThanFilter<T>
    {
        [JsonProperty("$lt")]
        public T LessThanValue { get; set; }

        public LessThanFilter(T lessThanValue)
        {
            LessThanValue = lessThanValue;
        }
    }
}