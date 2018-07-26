using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.Roadster;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get Roadster information.
    /// </summary>
    public class Roadster
    {
        private HttpClient _httpClient;
        private BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Roadster"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public Roadster(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets information about Tesla Roadster sent on Falcon Heavy. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The Roadster builder.</returns>
        public RoadsterBuilder Get()
        {
            return new RoadsterBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}
