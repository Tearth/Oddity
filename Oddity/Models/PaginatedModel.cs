using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.Builders;
using Oddity.Models.Query;

namespace Oddity.Models
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

        private QueryBuilder<T> _builder;

        public void SetBuilder(QueryBuilder<T> builder)
        {
            _builder = builder;
        }

        public async Task<bool> GoToNextPage()
        {
            if (NextPage == null)
            {
                return false;
            }

            Data.Clear();
            _builder.WithPage(NextPage.Value);

            return await _builder.ExecuteAsync(this);
        }

        public async Task<bool> GoToPrevPage()
        {
            if (PrevPage == null)
            {
                return false;
            }

            Data.Clear();
            _builder.WithPage(PrevPage.Value);

            return await _builder.ExecuteAsync(this);
        }

        public async Task<bool> GoToFirstPage()
        {
            Data.Clear();
            _builder.WithPage(1);

            return await _builder.ExecuteAsync(this);
        }

        public async Task<bool> GoToLastPage()
        {
            Data.Clear();
            _builder.WithPage(TotalPages);

            return await _builder.ExecuteAsync(this);
        }

        public async Task<bool> GoToPage(uint page)
        {
            if (page > TotalPages)
            {
                return false;
            }

            Data.Clear();
            _builder.WithPage(page);

            return await _builder.ExecuteAsync(this);
        }
    }
}
