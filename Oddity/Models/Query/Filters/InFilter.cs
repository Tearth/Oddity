using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Oddity.Models.Query.Filters
{
    public class InFilter<TData>
    {
        [JsonProperty("$in")]
        public List<TData> Values { get; set; }

        public InFilter(params TData[] values)
        {
            Values = values.ToList();
        }
    }
}