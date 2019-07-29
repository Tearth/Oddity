using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Launchpad;

namespace Oddity.API.Builders.Launchpads
{
    /// <summary>
    /// Represents a set of methods to filter all launchpads information and download them from API.
    /// </summary>
    public class AllLaunchpadsBuilder : BuilderBase<List<LaunchpadInfo>>
    {
        private const string LaunchpadInfoEndpoint = "launchpads";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllLaunchpadsBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public AllLaunchpadsBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <inheritdoc />
        protected override async Task<List<LaunchpadInfo>> ExecuteBuilder()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
