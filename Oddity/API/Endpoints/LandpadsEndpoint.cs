using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Crew;
using Oddity.API.Models.Landspads;
using Oddity.API.Models.Payloads;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /landpads endpoint.
    /// </summary>
    public class LandpadsEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LandpadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public LandpadsEndpoint(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets data about the specified landpad from the /landpads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified payload.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LandpadInfo> Get(string id)
        {
            return new SimpleBuilder<LandpadInfo>(_httpClient, "landpads", id, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about crew from the /landpads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<List<LandpadInfo>> GetAll()
        {
            return new SimpleBuilder<List<LandpadInfo>>(_httpClient, "landpads", _builderDelegatesContainer);
        }
    }
}