using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Starlink;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /starlink endpoint.
    /// </summary>
    public class StarlinkEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="StarlinkEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public StarlinkEndpoint(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets data about the specified Starlink satellite from the /starlink/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified Starlink satellite.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<StarlinkInfo> Get(string id)
        {
            return new SimpleBuilder<StarlinkInfo>(_httpClient, "starlink", id, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all Starlink satellites from the /starlink endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<StarlinkInfo> GetAll()
        {
            return new ListBuilder<StarlinkInfo>(_httpClient, "starlink", _builderDelegatesContainer);
        }
    }
}