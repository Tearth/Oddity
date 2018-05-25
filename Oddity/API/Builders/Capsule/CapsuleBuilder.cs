using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models.Capsule;
using Oddity.API.Models.Rocket;

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
        public CapsuleInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The capsule information.</returns>
        public async Task<CapsuleInfo> ExecuteAsync()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            if (_capsuleType.HasValue)
            {
                link += $"/{_capsuleType.ToString().ToLower()}";
            }

            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<CapsuleInfo>(json);
        }
    }
}
