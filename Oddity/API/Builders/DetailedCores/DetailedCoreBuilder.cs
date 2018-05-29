using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Builders.DetailedCore.Exceptions;
using Oddity.API.Models.DetailedCore;

namespace Oddity.API.Builders.DetailedCore
{
    public class DetailedCoreBuilder : BuilderBase<DetailedCoreInfo>
    {
        private string _capsuleSerial;
        private const string CapsuleInfoEndpoint = "parts/caps";

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedCoreBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public DetailedCoreBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <summary>
        /// Filters capsule information by the specified rocket type. Note that you have to call <see cref="Execute"/> or
        /// <see cref="ExecuteAsync"/> to get result from the API. Every next call of this method will
        /// override previously saved capsule type filter.
        /// </summary>
        /// <param name="type">The capsule type (Dragon1, Dragon2, etc).</param>
        /// <returns>The capsule information.</returns>
        public DetailedCoreBuilder WithSerial(string capsuleSerial)
        {
            _capsuleSerial = capsuleSerial;
            return this;
        }

        /// <inheritdoc />
        public override DetailedCoreInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <inheritdoc />
        /// <exception cref="CoreSerialNotSelectedException">Thrown when user tries to get API data without selected capsule serial.</exception>
        public override async Task<DetailedCoreInfo> ExecuteAsync()
        {
            if (_capsuleSerial == null)
            {
                throw new CoreSerialNotSelectedException();
            }

            var link = BuildLink(CapsuleInfoEndpoint);
            if (_capsuleSerial != null)
            {
                link += $"/{_capsuleSerial.ToUpper()}";
            }

            return await RequestForObject(link);
        }
    }
}
