using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Crew;
using Oddity.API.Models.Payloads;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /crew endpoint.
    /// </summary>
    public class CrewEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrewEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public CrewEndpoint(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets data about the specified crew member from the /crew/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified payload.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<CrewInfo> Get(string id)
        {
            return new SimpleBuilder<CrewInfo>(_httpClient, "crew", id, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about crew from the /crew endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<List<CrewInfo>> GetAll()
        {
            return new SimpleBuilder<List<CrewInfo>>(_httpClient, "crew", _builderDelegatesContainer);
        }
    }
}