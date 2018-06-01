using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.Capsules;
using Oddity.API.Models.Capsule;

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
        /// Gets information about the specified capsule. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <param name="capsuleType">The capsule type.</param>
        /// <returns>The capsule builder.</returns>
        public CapsuleBuilder GetAbout(CapsuleId capsuleType)
        {
            return new CapsuleBuilder(_httpClient, _deserializationError).WithType(capsuleType);
        }

        /// <summary>
        /// Gets information about all capsules. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all capsules builder.</returns>
        public AllCapsulesBuilder GetAll()
        {
            return new AllCapsulesBuilder(_httpClient, _deserializationError);
        }
    }
}
