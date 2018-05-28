using System.Net.Http;
using Oddity.API.Builders.Launch;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get launches information.
    /// </summary>
    public class Launches
    {
        private HttpClient _httpClient;
        private DeserializationError _deserializationError;

        /// <summary>
        /// Initializes a new instance of the <see cref="Launches"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public Launches(HttpClient httpClient, DeserializationError deserializationError)
        {
            _httpClient = httpClient;
            _deserializationError = deserializationError;
        }

        /// <summary>
        /// Gets information about all launches (past and upcoming). This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="AllLaunchesBuilder.Execute"/> or <see cref="AllLaunchesBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all launches builder.</returns>
        public AllLaunchesBuilder GetAll()
        {
            return new AllLaunchesBuilder(_httpClient, _deserializationError);
        }

        /// <summary>
        /// Gets information about latest launch. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="LatestLaunchesBuilder.Execute"/> or <see cref="LatestLaunchesBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The latest launch builder.</returns>
        public LatestLaunchesBuilder GetLatest()
        {
            return new LatestLaunchesBuilder(_httpClient, _deserializationError);
        }

        /// <summary>
        /// Gets information about next launch. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="NextLaunchesBuilder.Execute"/> or <see cref="NextLaunchesBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The next launch builder.</returns>
        public NextLaunchesBuilder GetNext()
        {
            return new NextLaunchesBuilder(_httpClient, _deserializationError);
        }

        /// <summary>
        /// Gets information about all upcoming launches. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="UpcomingLaunchesBuilder.Execute"/> or <see cref="UpcomingLaunchesBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all upcoming launches builder.</returns>
        public UpcomingLaunchesBuilder GetUpcoming()
        {
            return new UpcomingLaunchesBuilder(_httpClient, _deserializationError);
        }


        /// <summary>
        /// Gets information about past launches. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="PastLaunchesBuilder.Execute"/> or <see cref="PastLaunchesBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The past launches builder.</returns>
        public PastLaunchesBuilder GetPast()
        {
            return new PastLaunchesBuilder(_httpClient, _deserializationError);
        }
    }
}
