using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.Launchpads;
using Oddity.API.Models.Launchpad;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get launchpad information.
    /// </summary>
    public class Launchpads
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Launchpads"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public Launchpads(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets information about the specified launchpad. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <param name="launchpadType">The launchpad type.</param>
        /// <returns>The launchpad builder.</returns>
        public LaunchpadBuilder GetAbout(LaunchpadId launchpadType)
        {
            return new LaunchpadBuilder(_httpClient, _builderDelegatesContainer).WithType(launchpadType);
        }

        /// <summary>
        /// Gets information about all launchpads. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all launchpads builder.</returns>
        public AllLaunchpadsBuilder GetAll()
        {
            return new AllLaunchpadsBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}
