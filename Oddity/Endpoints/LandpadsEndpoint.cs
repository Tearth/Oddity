using Oddity.Builders;
using Oddity.Configuration;
using Oddity.Models;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point of /landpads endpoint.
    /// </summary>
    /// <typeparam name="TData">Type of the data returned from API.</typeparam>
    public class LandpadsEndpoint<TData> : EndpointBase<TData> where TData : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LandpadsEndpoint{TData}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        public LandpadsEndpoint(OddityCore context) : base(context, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified landpad from the /landpads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified landpad.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<TData> Get(string id)
        {
            return new SimpleBuilder<TData>(Context, Cache, "landpads", id);
        }

        /// <summary>
        /// Gets data about all landpads from the /landpads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<TData> GetAll()
        {
            return new ListBuilder<TData>(Context, Cache, "landpads");
        }

        /// <summary>
        /// Gets filtered and paginated data about all landpads from the /landpads/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<TData> Query()
        {
            return new QueryBuilder<TData>(Context, Cache, "landpads/query");
        }
    }
}