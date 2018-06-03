using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Launch;

namespace Oddity.API.Builders.Launches
{
    /// <summary>
    /// Represents a set of methods to filter all launches information and download them from API.
    /// </summary>
    public class AllLaunchesBuilder : LaunchBuilderBase<AllLaunchesBuilder, List<LaunchInfo>>
    {
        private const string LaunchpadInfoEndpoint = "launches/all";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllLaunchesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public AllLaunchesBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <inheritdoc />
        protected override async Task<List<LaunchInfo>> ExecuteBuilder()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            return await SendRequestToApi(link);
        }
    }
}
