using System.Net.Http;
using Oddity.API.Builders.Capsules;
using Oddity.API.Builders.DetailedCapsules;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get detailed capsules information.
    /// </summary>
    public class DetailedCapsules
    {
        private HttpClient _httpClient;
        private DeserializationError _deserializationError;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedCapsules"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public DetailedCapsules(HttpClient httpClient, DeserializationError deserializationError)
        {
            _httpClient = httpClient;
            _deserializationError = deserializationError;
        }

        /// <summary>
        /// Gets information about the specified capsule. Note that you have to call <see cref="DetailedCapsuleBuilder.WithSerial"/>
        /// before <see cref="DetailedCapsuleBuilder.Execute"/> or <see cref="DetailedCapsuleBuilder.ExecuteAsync"/> because otherwise there will
        /// be thrown an exception. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="DetailedCapsuleBuilder.Execute"/> or <see cref="DetailedCapsuleBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The capsule builder.</returns>
        public DetailedCapsuleBuilder GetAbout()
        {
            return new DetailedCapsuleBuilder(_httpClient, _deserializationError);
        }

        /// <summary>
        /// Gets detailed information about all capsules. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="AllDetailedCapsulesBuilder.Execute"/> or <see cref="AllDetailedCapsulesBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all detailed capsules builder.</returns>
        public AllDetailedCapsulesBuilder GetAll()
        {
            return new AllDetailedCapsulesBuilder(_httpClient, _deserializationError);
        }
    }
}
