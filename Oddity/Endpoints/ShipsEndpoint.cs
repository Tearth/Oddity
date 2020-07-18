using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models;
using Oddity.Models.Ships;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /ships endpoint.
    /// </summary>
    public class ShipsEndpoint<T> : EndpointBase<T> where T : ModelBase, IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public ShipsEndpoint(OddityCore context)
            : base(context, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified ship from the /ships/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified ship.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<T> Get(string id)
        {
            return new SimpleBuilder<T>(Context, Cache, "ships", id);
        }

        /// <summary>
        /// Gets data about all ships from the /ships endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<T> GetAll()
        {
            return new ListBuilder<T>(Context, Cache, "ships");
        }

        /// <summary>
        /// Gets filtered and paginated data about all ships from the /ships/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<T> Query()
        {
            return new QueryBuilder<T>(Context, Cache, "ships/query");
        }
    }
}