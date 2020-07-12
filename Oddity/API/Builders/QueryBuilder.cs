using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Oddity.API.Events;
using Oddity.API.Exceptions;
using Oddity.API.Models;
using Oddity.API.Models.Query;

namespace Oddity.API.Builders
{
    /// <summary>
    /// Represents a query builder used to retrieve data with filters specified by the user.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public class QueryBuilder<TReturn> : BuilderBase<PaginatedModel<TReturn>> where TReturn : ModelBase
    {
        private readonly string _endpoint;
        private readonly OddityCore _context;

        private readonly QueryModel _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public QueryBuilder(HttpClient httpClient, string endpoint, OddityCore context, BuilderDelegatesContainer builderDelegates) 
            : base(httpClient, builderDelegates)
        {
            _endpoint = endpoint;
            _context = context;
            _query = new QueryModel();
        }

        /// <inheritdoc />
        public override PaginatedModel<TReturn> Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override async Task<PaginatedModel<TReturn>> ExecuteAsync()
        {
            var content = await GetResponseFromEndpoint($"{_endpoint}", _query);
            var deserializedObjectsList = DeserializeJson(content);

            foreach (var deserializedObject in deserializedObjectsList.Data)
            {
                deserializedObject.SetContext(_context);
            }

            return deserializedObjectsList;
        }

        /// <summary>
        /// Adds a filter for the specified field which have to have an exact value.
        /// </summary>
        /// <typeparam name="T">Type of the field.</typeparam>
        /// <param name="fieldName">Name of the field (naming convention same as in models).</param>
        /// <param name="value">Value of the field to match.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldEqual<T>(string fieldName, T value)
        {
            _query.Filters.Add(fieldName, value);
            return this;
        }
    }
}