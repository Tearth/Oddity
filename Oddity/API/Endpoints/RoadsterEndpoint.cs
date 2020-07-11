using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Roadster;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /roadster endpoint.
    /// </summary>
    public class RoadsterEndpoint : EndpointBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoadsterEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public RoadsterEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegatesContainer builderDelegatesContainer)
            : base(httpClient, context, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Gets data about Roadster from the /roadster endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<RoadsterInfo> Get()
        {
            return new SimpleBuilder<RoadsterInfo>(HttpClient, "roadster", Context, BuilderDelegatesContainer);
        }
    }
}
