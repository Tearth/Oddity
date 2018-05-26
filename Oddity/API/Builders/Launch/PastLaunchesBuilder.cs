using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models.Launch;

namespace Oddity.API.Builders.Launch
{
    /// <summary>
    /// Represents a set of methods to filter all launches information and download them from API.
    /// </summary>
    public class PastLaunchesBuilder : LaunchBuilderBase<PastLaunchesBuilder>
    {
        private const string LaunchpadInfoEndpoint = "launches";

        /// <summary>
        /// Initializes a new instance of the <see cref="PastLaunchesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public PastLaunchesBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The all upcoming launches information.</returns>
        public List<LaunchInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The all upcoming launches information.</returns>
        public async Task<List<LaunchInfo>> ExecuteAsync()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<List<LaunchInfo>>(json);
        }
    }
}
