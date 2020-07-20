using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.Builders;

namespace Oddity.Models
{
    /// <summary>
    /// Represents an wrapper for a model, providing methods to manage a pagination.
    /// </summary>
    /// <typeparam name="TData">Type of the data returned from API.</typeparam>
    public class PaginatedModel<TData> where TData : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Gets or sets the total number of elements in <see cref="Data"/>.
        /// </summary>
        public uint TotalDocs { get; set; }

        /// <summary>
        /// Gets or sets the offset applied to the query.
        /// </summary>
        public uint Offset { get; set; }

        /// <summary>
        /// Gets or sets the limit applied to the query.
        /// </summary>
        public uint Limit { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public uint TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        public uint Page { get; set; }

        /// <summary>
        /// Gets or sets the starting serial number of first document.
        /// </summary>
        public uint PagingCounter { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating if there is a previous page available to switch.
        /// </summary>
        public bool HasPrevPage { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating if there is a next page available to switch.
        /// </summary>
        public bool HasNextPage { get; set; }

        /// <summary>
        /// Gets or sets the previous page number (only if <see cref="HasPrevPage"/> is set to true, otherwise null).
        /// </summary>
        public uint? PrevPage { get; set; }

        /// <summary>
        /// Gets or sets the next page number (only if <see cref="HasNextPage"/> is set to true, otherwise null).
        /// </summary>
        public uint? NextPage { get; set; }

        /// <summary>
        /// Gets or sets the collection of items returned from API for the query filters and parameters.
        /// </summary>
        [JsonProperty("docs")]
        public List<TData> Data { get; set; }

        private QueryBuilder<TData> _builder;
        
        /// <summary>
        /// Sets the builder which will be used to change pages.
        /// </summary>
        /// <param name="builder">Query builder used for page changes.</param>
        public void SetBuilder(QueryBuilder<TData> builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Changes the page to the specified in the <see cref="NextPage"/> and makes an request to API. 
        /// </summary>
        /// <returns>True if the page number was valid and has been changed with success, otherwise false.</returns>
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

        /// <summary>
        /// Changes the page to the specified in the <see cref="PrevPage"/> and makes an request to API. 
        /// </summary>
        /// <returns>True if the page number was valid and has been changed with success, otherwise false.</returns>
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

        /// <summary>
        /// Changes the page to the first and makes an request to API. 
        /// </summary>
        /// <returns>True if the page number was valid and has been changed with success, otherwise false.</returns>
        public async Task<bool> GoToFirstPage()
        {
            Data.Clear();
            _builder.WithPage(1);

            return await _builder.ExecuteAsync(this);
        }

        /// <summary>
        /// Changes the page to the specified in the <see cref="TotalPages"/> and makes an request to API. 
        /// </summary>
        /// <returns>True if the page number was valid and has been changed with success, otherwise false.</returns>
        public async Task<bool> GoToLastPage()
        {
            Data.Clear();
            _builder.WithPage(TotalPages);

            return await _builder.ExecuteAsync(this);
        }

        /// <summary>
        /// Changes the page to the specified in the parameter and makes an request to API. 
        /// </summary>
        /// <param name="page">Page number to be set.</param>
        /// <returns>True if the page number was valid and has been changed with success, otherwise false.</returns>
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
