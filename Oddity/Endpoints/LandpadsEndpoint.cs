using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models.Landpads;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /landpads endpoint.
    /// </summary>
    public class LandpadsEndpoint : EndpointBase
    {
        private CacheService<LandpadInfo> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="LandpadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public LandpadsEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates)
        {
            _cache = new CacheService<LandpadInfo>(LibraryConfiguration.MediumPriorityCacheLifetime);
        }

        /// <summary>
        /// Gets data about the specified landpad from the /landpads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified landpad.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LandpadInfo> Get(string id)
        {
            return new SimpleBuilder<LandpadInfo>(HttpClient, "landpads", id, Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets data about all landpads from the /landpads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LandpadInfo> GetAll()
        {
            return new ListBuilder<LandpadInfo>(HttpClient, "landpads", Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about all landpads from the /landpads/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<LandpadInfo> Query()
        {
            return new QueryBuilder<LandpadInfo>(HttpClient, "landpads/query", Context, _cache, BuilderDelegates);
        }
    }
}