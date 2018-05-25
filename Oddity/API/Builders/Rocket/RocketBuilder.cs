using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models.Rocket;

namespace Oddity.API.Builders.Rocket
{
    /// <summary>
    /// Represents a set of methods to filter rocket information and download them from API.
    /// </summary>
    public class RocketBuilder : BuilderBase
    {
        private RocketType? _rocketType;
        private const string RocketInfoEndpoint = "rockets";

        /// <summary>
        /// Initializes a new instance of the <see cref="RocketBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public RocketBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Filters rocket information by the specified rocket type. Note that you have to call <see cref="Execute"/> or
        /// <see cref="ExecuteAsync"/> to get result from the API. Every next call of this method will
        /// override previously saved rocket type filter.
        /// </summary>
        /// <param name="type">The rocket type (Falcon1, Falcon9, etc).</param>
        /// <returns>The rocket information.</returns>
        public RocketBuilder WithType(RocketType type)
        {
            _rocketType = type;
            return this;
        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The rocket information.</returns>
        public RocketInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The rocket information.</returns>
        public async Task<RocketInfo> ExecuteAsync()
        {
            var link = BuildLink(RocketInfoEndpoint);
            if (_rocketType.HasValue)
            {
                link += $"/{_rocketType.ToString().ToLower()}";
            }

            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<RocketInfo>(json);
        }
    }
}
