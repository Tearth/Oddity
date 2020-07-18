using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models.Crew;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /crew endpoint.
    /// </summary>
    public class CrewEndpoint : EndpointBase
    {
        private CacheService<CrewInfo> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrewEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public CrewEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates)
        {
            _cache = new CacheService<CrewInfo>(LibraryConfiguration.MediumPriorityCacheLifetime);
        }

        /// <summary>
        /// Gets data about the specified crew member from the /crew/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified crew member.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<CrewInfo> Get(string id)
        {
            return new SimpleBuilder<CrewInfo>(HttpClient, "crew", id, Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets data about crew from the /crew endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<CrewInfo> GetAll()
        {
            return new ListBuilder<CrewInfo>(HttpClient, "crew", Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about crew from the /crew/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<CrewInfo> Query()
        {
            return new QueryBuilder<CrewInfo>(HttpClient, "crew/query", Context, _cache, BuilderDelegates);
        }
    }
}