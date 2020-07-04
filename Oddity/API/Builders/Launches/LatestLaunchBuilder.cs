using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Launch;

namespace Oddity.API.Builders.Launches
{
    /// <summary>
    /// Represents a set of methods to filter past launch information and download them from API.
    /// </summary>
    public class LatestLaunchesBuilder : BuilderBase<LaunchInfo>
    {
        private const string LaunchesEndpoint = "launches/latest";

        /// <summary>
        /// Initializes a new instance of the <see cref="LatestLaunchesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public LatestLaunchesBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <inheritdoc />
        protected override async Task<LaunchInfo> ExecuteBuilder()
        {
            var link = BuildLink(LaunchesEndpoint);
            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
