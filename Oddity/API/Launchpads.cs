using System.Net.Http;
using Oddity.API.Builders.Launchpads;
using Oddity.API.Models.Launchpad;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get launchpad information.
    /// </summary>
    public class Launchpads
    {
        private HttpClient _httpClient;
        private DeserializationError _deserializationError;

        /// <summary>
        /// Initializes a new instance of the <see cref="Launchpads"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public Launchpads(HttpClient httpClient, DeserializationError deserializationError)
        {
            _httpClient = httpClient;
            _deserializationError = deserializationError;
        }

        /// <summary>
        /// Gets information about the specified launchpad. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="LaunchpadBuilder.Execute"/> or <see cref="LaunchpadBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <param name="launchpadType">The launchpad type.</param>
        /// <returns>The launchpad builder.</returns>
        public LaunchpadBuilder GetAbout(LaunchpadId launchpadType)
        {
            return new LaunchpadBuilder(_httpClient, _deserializationError).WithType(launchpadType);
        }

        /// <summary>
        /// Gets information about all launchpads. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="AllLaunchpadsBuilder.Execute"/> or <see cref="AllLaunchpadsBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all launchpads builder.</returns>
        public AllLaunchpadsBuilder GetAll()
        {
            return new AllLaunchpadsBuilder(_httpClient, _deserializationError);
        }
    }
}
