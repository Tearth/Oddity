using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.Rockets;
using Oddity.API.Models.Rocket;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get rockets information.
    /// </summary>
    public class Rockets
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rockets"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public Rockets(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets information about the specified rocket. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <param name="rocketType">The rocket type.</param>
        /// <returns>The rocket builder.</returns>
        public RocketBuilder GetAbout(RocketId rocketType)
        {
            return new RocketBuilder(_httpClient, _builderDelegatesContainer).WithType(rocketType);
        }

        /// <summary>
        /// Gets information about all rockets. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all rockets builder.</returns>
        public AllRocketsBuilder GetAll()
        {
            return new AllRocketsBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}
