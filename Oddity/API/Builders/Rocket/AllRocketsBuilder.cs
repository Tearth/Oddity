using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Exceptions;
using Oddity.API.Models.Rocket;

namespace Oddity.API.Builders.Rocket
{
    /// <summary>
    /// Represents a set of methods to filter all rockets information and download them from API.
    /// </summary>
    public class AllRocketsBuilder : BuilderBase
    {
        private const string RocketInfoEndpoint = "rockets";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllRocketsBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public AllRocketsBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The all rockets information.</returns>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public List<RocketInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The all rockets information.</returns>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public async Task<List<RocketInfo>> ExecuteAsync()
        {
            var link = BuildLink(RocketInfoEndpoint);
            return await RequestForObject<List<RocketInfo>>(link);
        }
    }
}
