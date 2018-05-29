using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Oddity.API.Builders.Capsule;
using Oddity.API.Builders.Capsule.Exceptions;
using Oddity.API.Builders.DetailedCapsule.Exceptions;
using Oddity.API.Models.Capsule;
using Oddity.API.Models.DetailedCapsule;

namespace Oddity.API.Builders.DetailedCapsule
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
        /// Filters capsule information by the specified rocket type. Note that you have to call <see cref="Execute"/> or
        /// <see cref="ExecuteAsync"/> to get result from the API. Every next call of this method will
        /// override previously saved capsule type filter.
        /// </summary>
        /// <param name="type">The capsule type (Dragon1, Dragon2, etc).</param>
        /// <returns>The capsule information.</returns>
        public DetailedCapsuleBuilder WithSerial(string capsuleSerial)
        {
            _capsuleSerial = capsuleSerial;
            return this;
        }

        /// <inheritdoc />
        public override DetailedCapsuleInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <inheritdoc />
        /// <exception cref="CapsuleSerialNotSelectedException">Thrown when user tries to get API data without selected capsule serial.</exception>
        public override async Task<DetailedCapsuleInfo> ExecuteAsync()
        {
            if (_capsuleSerial == null)
            {
                throw new CapsuleSerialNotSelectedException();
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
