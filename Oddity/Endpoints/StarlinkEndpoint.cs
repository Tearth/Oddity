using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models;
using Oddity.Models.Starlink;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /starlink endpoint.
    /// </summary>
    public class StarlinkEndpoint<T> : EndpointBase<T> where T : ModelBase, IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StarlinkEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public StarlinkEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified Starlink satellite from the /starlink/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified Starlink satellite.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<T> Get(string id)
        {
            return new SimpleBuilder<T>(HttpClient, "starlink", id, Context, Cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets data about all Starlink satellites from the /starlink endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<T> GetAll()
        {
            return new ListBuilder<T>(HttpClient, "starlink", Context, Cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about all Starlink satellites from the /starlink/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<T> Query()
        {
            return new QueryBuilder<T>(HttpClient, "starlink/query", Context, Cache, BuilderDelegates);
        }
    }
}