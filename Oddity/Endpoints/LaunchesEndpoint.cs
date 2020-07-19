using Oddity.Builders;
using Oddity.Configuration;
using Oddity.Models;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point of /launches endpoint.
    /// </summary>
    /// <typeparam name="TData">Type of the data returned from API.</typeparam>
    public class LaunchesEndpoint<TData> : EndpointBase<TData> where TData : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchesEndpoint{T}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        public LaunchesEndpoint(OddityCore context) : base(context, LibraryConfiguration.HighPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified launch from the /launches/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified launch.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<TData> Get(string id)
        {
            return new SimpleBuilder<TData>(Context, Cache, "launches", id);
        }

        /// <summary>
        /// Gets data about the latest launch from the /launches/latest endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<TData> GetLatest()
        {
            return new SimpleBuilder<TData>(Context, Cache, "launches/latest");
        }

        /// <summary>
        /// Gets data about the next launch from the /launches/next endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<TData> GetNext()
        {
            return new SimpleBuilder<TData>(Context, Cache, "launches/next");
        }

        /// <summary>
        /// Gets data about all launches from the /launches endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<TData> GetAll()
        {
            return new ListBuilder<TData>(Context, Cache, "launches");
        }

        /// <summary>
        /// Gets data about all past launches from the /launches/past endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<TData> GetPast()
        {
            return new ListBuilder<TData>(Context, Cache, "launches/past");
        }

        /// <summary>
        /// Gets data about all upcoming launches from the /launches/upcoming endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<TData> GetUpcoming()
        {
            return new ListBuilder<TData>(Context, Cache, "launches/upcoming");
        }

        /// <summary>
        /// Gets filtered and paginated data about all launches from the /launches/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<TData> Query()
        {
            return new QueryBuilder<TData>(Context, Cache, "launches/query");
        }
    }
}