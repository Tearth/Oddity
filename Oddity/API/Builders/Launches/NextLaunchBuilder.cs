using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Launch;

namespace Oddity.API.Builders.Launches
{
    /// <summary>
    /// Represents a set of methods to filter latest launch information and download them from API.
    /// </summary>
    public class NextLaunchesBuilder : BuilderBase<LaunchInfo>
    {
        private const string LaunchpadInfoEndpoint = "launches/next";

        /// <summary>
        /// Initializes a new instance of the <see cref="NextLaunchesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public NextLaunchesBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <inheritdoc />
        protected override async Task<LaunchInfo> ExecuteBuilder()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
