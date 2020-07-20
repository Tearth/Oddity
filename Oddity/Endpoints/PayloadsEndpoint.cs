using Oddity.Builders;
using Oddity.Configuration;
using Oddity.Models;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point of /payloads endpoint.
    /// </summary>
    /// <typeparam name="TData">Type of the data returned from API.</typeparam>
    public class PayloadsEndpoint<TData> : EndpointBase<TData> where TData : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayloadsEndpoint{TData}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        public PayloadsEndpoint(OddityCore context) : base(context, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified payload from the /payloads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified payload.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<TData> Get(string id)
        {
            return new SimpleBuilder<TData>(Context, Cache, "payloads", id);
        }

        /// <summary>
        /// Gets data about all payloads from the /payloads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<TData> GetAll()
        {
            return new ListBuilder<TData>(Context, Cache, "payloads");
        }

        /// <summary>
        /// Gets filtered and paginated data about all payloads from the /payloads/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<TData> Query()
        {
            return new QueryBuilder<TData>(Context, Cache, "payloads/query");
        }
    }
}