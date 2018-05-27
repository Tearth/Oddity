using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Builders.Capsule.Exceptions;
using Oddity.API.Exceptions;
using Oddity.API.Models.Capsule;

namespace Oddity.API.Builders.Capsule
{
    /// <summary>
    /// Represents a set of methods to filter capsule information and download them from API.
    /// </summary>
    public class CapsuleBuilder : BuilderBase
    {
        private CapsuleId? _capsuleType;
        private const string CapsuleInfoEndpoint = "capsules";

        /// <summary>
        /// Initializes a new instance of the <see cref="CapsuleBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public CapsuleBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Filters capsule information by the specified rocket type. Note that you have to call <see cref="Execute"/> or
        /// <see cref="ExecuteAsync"/> to get result from the API. Every next call of this method will
        /// override previously saved capsule type filter.
        /// </summary>
        /// <param name="type">The capsule type (Dragon1, Dragon2, etc).</param>
        /// <returns>The capsule information.</returns>
        public CapsuleBuilder WithType(CapsuleId type)
        {
            _capsuleType = type;
            return this;
        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The capsule information.</returns>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public CapsuleInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The capsule information.</returns>
        /// <exception cref="CapsuleTypeNotSelectedException">Thrown when user tries to call <see cref="Execute"/>
        /// or <see cref="ExecuteAsync"/> without selected capsule type through <see cref="WithType"/>.</exception>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public async Task<CapsuleInfo> ExecuteAsync()
        {
            if (!_capsuleType.HasValue)
            {
                throw new CapsuleTypeNotSelectedException();
            }

            var link = BuildLink(CapsuleInfoEndpoint);
            if (_capsuleType.HasValue)
            {
                link += $"/{_capsuleType.ToString().ToLower()}";
            }

            return await RequestForObject<CapsuleInfo>(link);
        }
    }
}
