using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models.Launch;
using Oddity.API.Models.Launchpad;
using Oddity.API.Models.Rocket;

namespace Oddity.API.Builders.Launches
{
    /// <summary>
    /// Represents a set of methods to filter latest launch information and download them from API.
    /// </summary>
    public class NextLaunchesBuilder : BuilderBase
    {
        private const string LaunchpadInfoEndpoint = "launches/next";

        /// <summary>
        /// Initializes a new instance of the <see cref="NextLaunchesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public NextLaunchesBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The next launch information.</returns>
        public LaunchInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The next launch information.</returns>
        public async Task<LaunchInfo> ExecuteAsync()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<LaunchInfo>(json);
        }
    }
}
