using System.Net.Http;
using Oddity.API.Builders.Capsule;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get capsules information.
    /// </summary>
    public class Capsule
    {
        private HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Capsule"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public Capsule(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
            return new CapsuleBuilder(_httpClient);
        }

        /// <summary>
        /// Gets information about all capsules. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="AllCapsulesBuilder.Execute"/> or <see cref="AllCapsulesBuilder.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all capsules builder.</returns>
        public AllCapsulesBuilder GetAll()
        {
            return new AllCapsulesBuilder(_httpClient);
        }
    }
}
