using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models
{
    public class PaginatedModel<T> where T : ModelBase
    {
        public uint TotalDocs { get; set; }
        public uint Offset { get; set; }
        public uint Limit { get; set; }
        public uint TotalPages { get; set; }
        public uint Page { get; set; }
        public uint PagingCounter { get; set; }
        public bool HasPrevPage { get; set; }
        public bool HasNextPage { get; set; }
        public uint? PrevPage { get; set; }
        public uint? NextPage { get; set; }

        [JsonProperty("docs")]
        public List<T> Data { get; private set; }
    }
}
