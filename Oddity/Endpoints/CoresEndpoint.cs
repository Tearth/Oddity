using Oddity.Builders;
using Oddity.Configuration;
using Oddity.Models;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point of /cores endpoint.
    /// </summary>
    /// <typeparam name="TData">Type of the data returned from API.</typeparam>
    public class CoresEndpoint<TData> : EndpointBase<TData> where TData : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoresEndpoint{T}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        public CoresEndpoint(OddityCore context) : base(context, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified core from the /cores/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified cores.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<TData> Get(string id)
        {
            return new SimpleBuilder<TData>(Context, Cache, "cores", id);
        }

        /// <summary>
        /// Gets data about all cores from the /cores endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<TData> GetAll()
        {
            return new ListBuilder<TData>(Context, Cache, "cores");
        }

        /// <summary>
        /// Gets filtered and paginated data about all cores from the /cores/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<TData> Query()
        {
            return new QueryBuilder<TData>(Context, Cache, "cores/query");
        }
    }
}