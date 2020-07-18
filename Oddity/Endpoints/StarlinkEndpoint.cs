using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models.Starlink;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /starlink endpoint.
    /// </summary>
    public class StarlinkEndpoint : EndpointBase
    {
        private CacheService<StarlinkInfo> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="StarlinkEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public StarlinkEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates)
        {
            _cache = new CacheService<StarlinkInfo>(LibraryConfiguration.MediumPriorityCacheLifetime);
        }

        /// <summary>
        /// Gets data about the specified Starlink satellite from the /starlink/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified Starlink satellite.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<StarlinkInfo> Get(string id)
        {
            return new SimpleBuilder<StarlinkInfo>(HttpClient, "starlink", id, Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets data about all Starlink satellites from the /starlink endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<StarlinkInfo> GetAll()
        {
            return new ListBuilder<StarlinkInfo>(HttpClient, "starlink", Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about all Starlink satellites from the /starlink/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<StarlinkInfo> Query()
        {
            return new QueryBuilder<StarlinkInfo>(HttpClient, "starlink/query", Context, BuilderDelegates);
        }
    }
}