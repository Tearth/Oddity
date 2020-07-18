using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models;
using Oddity.Models.Landpads;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /landpads endpoint.
    /// </summary>
    public class LandpadsEndpoint<T> : EndpointBase<T> where T : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LandpadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public LandpadsEndpoint(OddityCore context)
            : base(context, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified landpad from the /landpads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified landpad.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<T> Get(string id)
        {
            return new SimpleBuilder<T>(Context, Cache, "landpads", id);
        }

        /// <summary>
        /// Gets data about all landpads from the /landpads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<T> GetAll()
        {
            return new ListBuilder<T>(Context, Cache, "landpads");
        }

        /// <summary>
        /// Gets filtered and paginated data about all landpads from the /landpads/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<T> Query()
        {
            return new QueryBuilder<T>(Context, Cache, "landpads/query");
        }
    }
}