using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Exceptions;
using Oddity.API.Models.Launchpad;

namespace Oddity.API.Builders.Launchpad
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
        public AllLaunchpadsBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <inheritdoc />
        public override List<LaunchpadInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <inheritdoc />
        public override async Task<List<LaunchpadInfo>> ExecuteAsync()
        {
            var link = BuildLink(LaunchpadInfoEndpoint);
            return await RequestForObject(link);
        }
    }
}
