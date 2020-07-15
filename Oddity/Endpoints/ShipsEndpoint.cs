using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Events;
using Oddity.Models.Ships;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /ships endpoint.
    /// </summary>
    public class ShipsEndpoint : EndpointBase
    {
        private CacheService<ShipInfo> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public ShipsEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates)
        {
            _cache = new CacheService<ShipInfo>(60 * 5);
        }

        /// <summary>
        /// Gets data about the specified ship from the /ships/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified ship.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<ShipInfo> Get(string id)
        {
            return new SimpleBuilder<ShipInfo>(HttpClient, "ships", id, Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets data about all ships from the /ships endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<ShipInfo> GetAll()
        {
            return new ListBuilder<ShipInfo>(HttpClient, "ships", Context, BuilderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about all ships from the /ships/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<ShipInfo> Query()
        {
            return new QueryBuilder<ShipInfo>(HttpClient, "ships/query", Context, BuilderDelegates);
        }
    }
}