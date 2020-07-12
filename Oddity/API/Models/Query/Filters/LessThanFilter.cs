using Newtonsoft.Json;

namespace Oddity.API.Models.Query.Filters
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