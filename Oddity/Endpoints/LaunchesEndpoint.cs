using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models;
using Oddity.Models.Launches;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /launches endpoint.
    /// </summary>
    public class LaunchesEndpoint<T> : EndpointBase<T> where T : ModelBase, IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchesEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public LaunchesEndpoint(OddityCore context)
            : base(context, LibraryConfiguration.HighPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified launch from the /launches/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified launch.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<T> Get(string id)
        {
            return new SimpleBuilder<T>("launches", id, Context, Cache);
        }

        /// <summary>
        /// Gets data about the latest launch from the /launches/latest endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<T> GetLatest()
        {
            return new SimpleBuilder<T>("launches/latest", Context, Cache);
        }

        /// <summary>
        /// Gets data about the next launch from the /launches/next endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<T> GetNext()
        {
            return new SimpleBuilder<T>("launches/next", Context, Cache);
        }

        /// <summary>
        /// Gets data about all launches from the /launches endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<T> GetAll()
        {
            return new ListBuilder<T>("launches", Context, Cache);
        }

        /// <summary>
        /// Gets data about all past launches from the /launches/past endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<T> GetPast()
        {
            return new ListBuilder<T>("launches/past", Context, Cache);
        }

        /// <summary>
        /// Gets data about all upcoming launches from the /launches/upcoming endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<T> GetUpcoming()
        {
            return new ListBuilder<T>("launches/upcoming", Context, Cache);
        }

        /// <summary>
        /// Gets filtered and paginated data about all launches from the /launches/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<T> Query()
        {
            return new QueryBuilder<T>("launches/query", Context, Cache);
        }
    }
}