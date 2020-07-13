using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Oddity.API.Models.Query.Filters
{
    public class InFilter<T>
    {
        [JsonProperty("$in")]
        public List<T> Values { get; set; }

        public InFilter(params T[] values)
        {
            Values = values.ToList();
        }
    }
}