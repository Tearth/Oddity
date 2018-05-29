using System.Net.Http;
using Oddity.API.Builders.Capsule;
using Oddity.API.Builders.DetailedCapsule;

namespace Oddity.API
{
    public class DetailedCore
    {
        private HttpClient _httpClient;
        private DeserializationError _deserializationError;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedCore"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public DetailedCore(HttpClient httpClient, DeserializationError deserializationError)
        {
            _httpClient = httpClient;
            _deserializationError = deserializationError;
        }

        /// <summary>
        /// Gets information about the specified capsule. Note that you have to call <see cref="CapsuleBuilder.WithType"/>
        /// before <see cref="CapsuleBuilder.Execute"/> or <see cref="CapsuleBuilder.ExecuteAsync"/> because otherwise there will
        /// be thrown an exception. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="CapsuleBuilder.Execute"/> or <see cref="CapsuleBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The capsule builder.</returns>
        /*public DetailedCapsuleBuilder GetAbout()
        {
            return new DetailedCapsuleBuilder(_httpClient, _deserializationError);
        }*/

        /// <summary>
        /// Gets detailed information about all cores. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="AllDetailedCapsulesBuilder.Execute"/> or <see cref="AllDetailedCapsulesBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all detailed core builder.</returns>
        public AllDetailedCoreBuilder GetAll()
        {
            return new AllDetailedCoreBuilder(_httpClient, _deserializationError);
        }
    }
}
