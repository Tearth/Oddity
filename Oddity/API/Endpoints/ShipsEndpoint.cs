using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Ships;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /ships endpoint.
    /// </summary>
    public class ShipsEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public ShipsEndpoint(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets data about the specified ship from the /ships/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified ship.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<ShipInfo> Get(string id)
        {
            return new SimpleBuilder<ShipInfo>(_httpClient, "ships", id, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all ships from the /ships endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<ShipInfo> GetAll()
        {
            return new ListBuilder<ShipInfo>(_httpClient, "ships", _builderDelegatesContainer);
        }
    }
}