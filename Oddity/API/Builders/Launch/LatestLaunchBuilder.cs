using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Launch;

namespace Oddity.API.Builders.Launch
{
    /// <summary>
    /// Represents a set of methods to filter past launch information and download them from API.
    /// </summary>
    public class LatestLaunchesBuilder : BuilderBase
    {
        private const string LaunchpadInfoEndpoint = "launches/latest";

        /// <summary>
        /// Initializes a new instance of the <see cref="LatestLaunchesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public LatestLaunchesBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The past launch information.</returns>
        public LaunchInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The past launch information.</returns>
        public async Task<LaunchInfo> ExecuteAsync()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<LaunchInfo>(json);
        }
    }
}
