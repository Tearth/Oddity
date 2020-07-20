using Oddity.Builders;
using Oddity.Configuration;
using Oddity.Models;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point of /company endpoint.
    /// </summary>
    /// <typeparam name="TData">Type of the data returned from API.</typeparam>
    public class CompanyEndpoint<TData> : EndpointBase<TData> where TData : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyEndpoint{TData}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        public CompanyEndpoint(OddityCore context) : base(context, LibraryConfiguration.LowPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about company from the /company endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<TData> Get()
        {
            return new SimpleBuilder<TData>(Context, Cache, "company");
        }
    }
}