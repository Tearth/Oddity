using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models;
using Oddity.Models.Launchpads;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /launchpads endpoint.
    /// </summary>
    public class LaunchpadsEndpoint<T> : EndpointBase<T> where T : ModelBase, IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchpadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public LaunchpadsEndpoint(OddityCore context)
            : base(context, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified launchpad from the /launchpads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified launchpad.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<T> Get(string id)
        {
            return new SimpleBuilder<T>(Context, Cache, "launchpads", id);
        }

        /// <summary>
        /// Gets data about all launchpads from the /launchpads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<T> GetAll()
        {
            return new ListBuilder<T>(Context, Cache, "launchpads");
        }

        /// <summary>
        /// Gets filtered and paginated data about all launchpads from the /launchpads/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<T> Query()
        {
            return new QueryBuilder<T>(Context, Cache, "launchpads/query");
        }
    }
}