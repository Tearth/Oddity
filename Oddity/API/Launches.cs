using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.Launches;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get launches information.
    /// </summary>
    public class Launches
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Launches"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public Launches(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets information about all launches (past and upcoming). This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all launches builder.</returns>
        public AllLaunchesBuilder GetAll()
        {
            return new AllLaunchesBuilder(_httpClient, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets information about latest launch. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The latest launch builder.</returns>
        public LatestLaunchesBuilder GetLatest()
        {
            return new LatestLaunchesBuilder(_httpClient, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets information about next launch. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The next launch builder.</returns>
        public NextLaunchesBuilder GetNext()
        {
            return new NextLaunchesBuilder(_httpClient, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets information about all upcoming launches. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all upcoming launches builder.</returns>
        public UpcomingLaunchesBuilder GetUpcoming()
        {
            return new UpcomingLaunchesBuilder(_httpClient, _builderDelegatesContainer);
        }


        /// <summary>
        /// Gets information about past launches. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The past launches builder.</returns>
        public PastLaunchesBuilder GetPast()
        {
            return new PastLaunchesBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}
