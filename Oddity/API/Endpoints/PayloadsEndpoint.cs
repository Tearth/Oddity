using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Payloads;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /payloads endpoint.
    /// </summary>
    public class PayloadsEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayloadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public PayloadsEndpoint(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets data about the specified payload from the /payloads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified payload.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<PayloadInfo> Get(string id)
        {
            return new SimpleBuilder<PayloadInfo>(_httpClient, "payloads", id, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all payloads from the /payloads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<PayloadInfo> GetAll()
        {
            return new ListBuilder<PayloadInfo>(_httpClient, "payloads", _builderDelegatesContainer);
        }
    }
}