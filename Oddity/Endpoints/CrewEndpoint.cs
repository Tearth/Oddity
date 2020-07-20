using Oddity.Builders;
using Oddity.Configuration;
using Oddity.Models;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point of /crew endpoint.
    /// </summary>
    /// <typeparam name="TData">Type of the data returned from API.</typeparam>
    public class CrewEndpoint<TData> : EndpointBase<TData> where TData : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrewEndpoint{TData}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        public CrewEndpoint(OddityCore context) : base(context, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified crew member from the /crew/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified crew member.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<TData> Get(string id)
        {
            return new SimpleBuilder<TData>(Context, Cache, "crew", id);
        }

        /// <summary>
        /// Gets data about crew from the /crew endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<TData> GetAll()
        {
            return new ListBuilder<TData>(Context, Cache, "crew");
        }

        /// <summary>
        /// Gets filtered and paginated data about crew from the /crew/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<TData> Query()
        {
            return new QueryBuilder<TData>(Context, Cache, "crew/query");
        }
    }
}