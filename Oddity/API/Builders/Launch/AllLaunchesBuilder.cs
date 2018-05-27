using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Exceptions;
using Oddity.API.Models.Launch;

namespace Oddity.API.Builders.Launch
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
        public AllLaunchesBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <inheritdoc />
        public override List<LaunchInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <inheritdoc />
        public override async Task<List<LaunchInfo>> ExecuteAsync()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            return await RequestForObject<List<LaunchInfo>>(link);
        }
    }
}
