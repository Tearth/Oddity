using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Launchpads;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /launchpads endpoint.
    /// </summary>
    public class LaunchpadsEndpoint : EndpointBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchpadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public LaunchpadsEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegatesContainer builderDelegatesContainer)
            : base(httpClient, context, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Gets data about the specified launchpad from the /launchpads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified launchpad.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LaunchpadInfo> Get(string id)
        {
            return new SimpleBuilder<LaunchpadInfo>(HttpClient, "launchpads", id, Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all launchpads from the /launchpads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LaunchpadInfo> GetAll()
        {
            return new ListBuilder<LaunchpadInfo>(HttpClient, "launchpads", Context, BuilderDelegatesContainer);
        }
    }
}