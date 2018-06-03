using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.DetailedCapsules;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get detailed capsules information.
    /// </summary>
    public class DetailedCapsules
    {
        private HttpClient _httpClient;
        private BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedCapsules"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public DetailedCapsules(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets information about the specified capsule. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <param name="capsuleSerial">The capsule serial.</param>
        /// <returns>The capsule builder.</returns>
        public DetailedCapsuleBuilder GetAbout(string capsuleSerial)
        {
            return new DetailedCapsuleBuilder(_httpClient, _builderDelegatesContainer).WithSerial(capsuleSerial);
        }

        /// <summary>
        /// Gets detailed information about all capsules. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all detailed capsules builder.</returns>
        public AllDetailedCapsulesBuilder GetAll()
        {
            return new AllDetailedCapsulesBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}
