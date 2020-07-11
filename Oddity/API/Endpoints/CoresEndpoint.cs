using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Cores;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /cores endpoint.
    /// </summary>
    public class CoresEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoresEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public CoresEndpoint(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets data about the specified core from the /cores/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified cores.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<CoreInfo> Get(string id)
        {
            return new SimpleBuilder<CoreInfo>(_httpClient, "cores", id, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all cores from the /cores endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<CoreInfo> GetAll()
        {
            return new ListBuilder<CoreInfo>(_httpClient, "cores", _builderDelegatesContainer);
        }
    }
}