using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Launch;

namespace Oddity.API.Builders.Launches
{
    /// <summary>
    /// Represents a set of methods to filter all launches information and download them from API.
    /// </summary>
    public class PastLaunchesBuilder : LaunchBuilderBase<PastLaunchesBuilder, List<LaunchInfo>>
    {
        private const string LaunchpadInfoEndpoint = "launches";

        /// <summary>
        /// Initializes a new instance of the <see cref="PastLaunchesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public PastLaunchesBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
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
