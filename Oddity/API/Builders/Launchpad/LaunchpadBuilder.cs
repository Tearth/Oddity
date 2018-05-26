using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Launchpad;
using Oddity.Helpers;

namespace Oddity.API.Builders.Launchpad
{
    /// <summary>
    /// Represents a set of methods to filter launchpad information and download them from API.
    /// </summary>
    public class LaunchpadBuilder : BuilderBase
    {
        private LaunchpadId? _launchpadType;
        private const string RocketInfoEndpoint = "launchpads";

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchpadBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public LaunchpadBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Filters launchpad information by the specified launchpad type. Note that you have to call <see cref="Execute"/> or
        /// <see cref="ExecuteAsync"/> to get result from the API. Every next call of this method will
        /// override previously saved launchpad type filter.
        /// </summary>
        /// <param name="type">The launchpad type (CcafsLc13, Stls, etc).</param>
        /// <returns>The launchpad information.</returns>
        public LaunchpadBuilder WithType(LaunchpadId type)
        {
            _launchpadType = type;
            return this;
        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The launchpad information.</returns>
        public LaunchpadInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The launchpad information.</returns>
        public async Task<LaunchpadInfo> ExecuteAsync()
        {
            var link = BuildLink(RocketInfoEndpoint);
            if (_launchpadType.HasValue)
            {
                var launchpadName = _launchpadType.GetEnumMemberAttrValue(_launchpadType);
                link += $"/{launchpadName.ToLower()}";
            }

            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<LaunchpadInfo>(json);
        }
    }
}
