using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models.Launchpads;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /launchpads endpoint.
    /// </summary>
    public class LaunchpadsEndpoint : EndpointBase
    {
        private CacheService<LaunchpadInfo> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchpadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public LaunchpadsEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates)
        {
            _cache = new CacheService<LaunchpadInfo>(LibraryConfiguration.MediumPriorityCacheLifetime);
        }

        /// <summary>
        /// Gets data about the specified launchpad from the /launchpads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified launchpad.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LaunchpadInfo> Get(string id)
        {
            return new SimpleBuilder<LaunchpadInfo>(HttpClient, "launchpads", id, Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets data about all launchpads from the /launchpads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LaunchpadInfo> GetAll()
        {
            return new ListBuilder<LaunchpadInfo>(HttpClient, "launchpads", Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about all launchpads from the /launchpads/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<LaunchpadInfo> Query()
        {
            return new QueryBuilder<LaunchpadInfo>(HttpClient, "launchpads/query", Context, _cache, BuilderDelegates);
        }
    }
}