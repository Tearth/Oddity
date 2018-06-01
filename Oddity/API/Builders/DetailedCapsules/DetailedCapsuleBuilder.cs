using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.DetailedCapsule;

namespace Oddity.API.Builders.DetailedCapsules
{
    /// <summary>
    /// Represents a set of methods to filter detailed capsule information and download them from API.
    /// </summary>
    public class DetailedCapsuleBuilder : BuilderBase<DetailedCapsuleInfo>
    {
        private string _capsuleSerial;
        private const string CapsuleInfoEndpoint = "parts/caps";

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedCapsuleBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public DetailedCapsuleBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <summary>
        /// Filters capsule information by the specified capsule serial. Note that you have to call <see cref="Execute"/> or
        /// <see cref="ExecuteAsync"/> to get result from the API. Every next call of this method will override previously saved capsule serial filter.
        /// </summary>
        /// <param name="capsuleSerial">The capsule serial (C101, C102, etc).</param>
        /// <returns>The capsule information.</returns>
        public DetailedCapsuleBuilder WithSerial(string capsuleSerial)
        {
            _capsuleSerial = capsuleSerial;
            return this;
        }

        /// <inheritdoc />
        /// <exception cref="CapsuleSerialNotSelectedException">Thrown when user tries to get API data without selected capsule serial.</exception>
        protected override async Task<DetailedCapsuleInfo> ExecuteBuilder()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            if (_capsuleSerial != null)
            {
                link += $"/{_capsuleSerial.ToUpper()}";
            }

            return await SendRequestToApi(link);
        }
    }
}
