using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Capsules;
using Oddity.API.Models.Cores;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /capsules endpoint.
    /// </summary>
    public class CapsulesEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CapsulesEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public CapsulesEndpoint(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets data about the specified capsule from the /capsules/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified capsule.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<CapsuleInfo> Get(string id)
        {
            return new SimpleBuilder<CapsuleInfo>(_httpClient, "capsules", id, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about capsules from the /capsules endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<List<CapsuleInfo>> GetAll()
        {
            return new SimpleBuilder<List<CapsuleInfo>>(_httpClient, "capsules", _builderDelegatesContainer);
        }
    }
}