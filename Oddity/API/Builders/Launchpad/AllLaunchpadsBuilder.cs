using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models.Launchpad;
using Oddity.API.Models.Rocket;

namespace Oddity.API.Builders.Launchpad
{
    /// <summary>
    /// Represents a set of methods to filter all launchpads information and download them from API.
    /// </summary>
    public class AllLaunchpadsBuilder : BuilderBase
    {
        private const string LaunchpadInfoEndpoint = "launchpads";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllLaunchpadsBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public AllLaunchpadsBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The all launchpads information.</returns>
        public List<LaunchpadInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The all launchpads information.</returns>
        public async Task<List<LaunchpadInfo>> ExecuteAsync()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<List<LaunchpadInfo>>(json);
        }
    }
}
