using Oddity.Builders;
using Oddity.Configuration;
using Oddity.Models;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point of /roadster endpoint.
    /// </summary>
    /// <typeparam name="TData">Type of the data returned from API.</typeparam>
    public class RoadsterEndpoint<TData> : EndpointBase<TData> where TData : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoadsterEndpoint{TData}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        public RoadsterEndpoint(OddityCore context) : base(context, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about Roadster from the /roadster endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<TData> Get()
        {
            return new SimpleBuilder<TData>(Context, Cache, "roadster", "");
        }
    }
}
