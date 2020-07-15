using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models.Roadster;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /roadster endpoint.
    /// </summary>
    public class RoadsterEndpoint : EndpointBase
    {
        private CacheService<RoadsterInfo> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoadsterEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public RoadsterEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates)
        {
            _cache = new CacheService<RoadsterInfo>(LibraryConfiguration.MediumPriorityCacheLifetime);
        }

        /// <summary>
        /// Gets data about Roadster from the /roadster endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<RoadsterInfo> Get()
        {
            return new SimpleBuilder<RoadsterInfo>(HttpClient, "roadster", Context, _cache, BuilderDelegates);
        }
    }
}
