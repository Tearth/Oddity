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
    public class LaunchpadsEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchpadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public LaunchpadsEndpoint(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets data about the specified launchpad from the /launchpads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified launchpad.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LaunchpadInfo> Get(string id)
        {
            return new SimpleBuilder<LaunchpadInfo>(_httpClient, "launchpads", id, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all launchpads from the /launchpads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LaunchpadInfo> GetAll()
        {
            return new ListBuilder<LaunchpadInfo>(_httpClient, "launchpads", _builderDelegatesContainer);
        }
    }
}