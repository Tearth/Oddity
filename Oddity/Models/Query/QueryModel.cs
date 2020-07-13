using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.Models.Query
{
    public class QueryModel
    {
        [JsonProperty("query")]
        public Dictionary<string, object> Filters { get; set; }

        [JsonProperty("options")]
        public QueryOptions Options { get; set; }

        public QueryModel()
        {
            Filters = new Dictionary<string, object>();
            Options = new QueryOptions();
        }
    }
}
