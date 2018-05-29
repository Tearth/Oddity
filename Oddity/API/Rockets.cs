using System.Net.Http;
using Oddity.API.Builders.Rockets;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get rockets information.
    /// </summary>
    public class Rockets
    {
        private HttpClient _httpClient;
        private DeserializationError _deserializationError;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rockets"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public Rockets(HttpClient httpClient, DeserializationError deserializationError)
        {
            _httpClient = httpClient;
            _deserializationError = deserializationError;
        }

        /// <summary>
        /// Gets information about the specified rocket. Note that you have to call <see cref="RocketBuilder.WithType"/>
        /// before <see cref="RocketBuilder.Execute"/> or <see cref="RocketBuilder.ExecuteAsync"/> because otherwise there will
        /// be thrown an exception. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="RocketBuilder.Execute"/> or <see cref="RocketBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The rocket builder.</returns>
        public RocketBuilder GetAbout()
        {
            return new RocketBuilder(_httpClient, _deserializationError);
        }

        /// <summary>
        /// Gets information about all rockets. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="AllRocketsBuilder.Execute"/> or <see cref="AllRocketsBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all rockets builder.</returns>
        public AllRocketsBuilder GetAll()
        {
            return new AllRocketsBuilder(_httpClient, _deserializationError);
        }
    }
}
