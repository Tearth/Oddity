using System.Net.Http;
using System.Threading.Tasks;
using Oddity.Events;
using Oddity.Models;
using Oddity.Models.Query;
using Oddity.Models.Query.Filters;

namespace Oddity.Builders
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

        /// <summary>
        /// Adds a filter for the specified field which have to have an value greater than specified.
        /// </summary>
        /// <typeparam name="T">Type of the field.</typeparam>
        /// <param name="fieldName">Name of the field (naming convention same as in models).</param>
        /// <param name="value">Max value of the field.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldGreaterThan<T>(string fieldName, T value)
        {
            _query.Filters.Add(fieldName, new GreaterThanFilter<T>(value));
            return this;
        }

        /// <summary>
        /// Adds a filter for the specified field which have to have an value less than specified.
        /// </summary>
        /// <typeparam name="T">Type of the field.</typeparam>
        /// <param name="fieldName">Name of the field (naming convention same as in models).</param>
        /// <param name="value">Min value of the field.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldLessThan<T>(string fieldName, T value)
        {
            _query.Filters.Add(fieldName, new LessThanFilter<T>(value));
            return this;
        }

        /// <summary>
        /// Adds a filter for the specified field which have to have an value within the specified range.
        /// </summary>
        /// <typeparam name="T">Type of the field.</typeparam>
        /// <param name="fieldName">Name of the field (naming convention same as in models).</param>
        /// <param name="from">Left side of the range.</param>
        /// <param name="to">Right side of the range.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldBetween<T>(string fieldName, T from, T to)
        {
            _query.Filters.Add(fieldName, new BetweenFilter<T>(from, to));
            return this;
        }

        /// <summary>
        /// Adds a filter for the specified field which have to have an value same as one of the specified.
        /// </summary>
        /// <typeparam name="T">Type of the field.</typeparam>
        /// <param name="fieldName">Name of the field (naming convention same as in models).</param>
        /// <param name="values">Values which have to be matched.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldIn<T>(string fieldName, params T[] values)
        {
            _query.Filters.Add(fieldName, new InFilter<T>(values));
            return this;
        }
    }
}