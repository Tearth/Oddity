using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models;
using Oddity.Models.Rockets;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /rockets endpoint.
    /// </summary>
    public class RocketsEndpoint<T> : EndpointBase<T> where T : ModelBase, IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RocketsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public RocketsEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates, LibraryConfiguration.LowPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified rocket from the /rockets/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified rocket.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<T> Get(string id)
        {
            return new SimpleBuilder<T>(HttpClient, "rockets", id, Context, Cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets data about all rockets from the /rockets endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<T> GetAll()
        {
            return new ListBuilder<T>(HttpClient, "rockets", Context, Cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about all rockets from the /rockets/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<T> Query()
        {
            return new QueryBuilder<T>(HttpClient, "rockets/query", Context, Cache, BuilderDelegates);
        }
    }
}