using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Launch;

namespace Oddity.API.Builders.Launch
{
    /// <summary>
    /// Represents a set of methods to filter past launch information and download them from API.
    /// </summary>
    public class LatestLaunchesBuilder : BuilderBase<LaunchInfo>
    {
        private const string LaunchpadInfoEndpoint = "launches/latest";

        /// <summary>
        /// Initializes a new instance of the <see cref="LatestLaunchesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public LatestLaunchesBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <inheritdoc />
        public override LaunchInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <inheritdoc />
        public override async Task<LaunchInfo> ExecuteAsync()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            return await RequestForObject(link);
        }
    }
}
