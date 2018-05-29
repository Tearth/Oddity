using System.Net.Http;
using Oddity.API.Builders.Capsules;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get capsules information.
    /// </summary>
    public class Capsules
    {
        private HttpClient _httpClient;
        private DeserializationError _deserializationError;

        /// <summary>
        /// Initializes a new instance of the <see cref="Capsules"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public Capsules(HttpClient httpClient, DeserializationError deserializationError)
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
        public CapsuleBuilder GetAbout()
        {
            return new CapsuleBuilder(_httpClient, _deserializationError);
        }

        /// <summary>
        /// Gets information about all capsules. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="AllCapsulesBuilder.Execute"/> or <see cref="AllCapsulesBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all capsules builder.</returns>
        public AllCapsulesBuilder GetAll()
        {
            return new AllCapsulesBuilder(_httpClient, _deserializationError);
        }
    }
}
