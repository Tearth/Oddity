using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Launch;

namespace Oddity.API.Builders.Launches
{
    /// <summary>
    /// Represents a set of methods to get the specified launch information and download them from API.
    /// </summary>
    public class LaunchBuilder : BuilderBase<LaunchInfo>
    {
        private int? _launchId;
        private const string LaunchesEndpoint = "launches";

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public LaunchBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Filters launch information by the specified ID. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or
        /// <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get result from the API. Every next call of this method will override previously saved capsule serial filter.
        /// </summary>
        /// <param name="launchId">The launch ID.</param>
        /// <returns>The launch information.</returns>
        public LaunchBuilder WithId(int launchId)
        {
            _launchId = launchId;
            return this;
        }

        /// <inheritdoc />
        protected override async Task<LaunchInfo> ExecuteBuilder()
        {
            var link = BuildLink(LaunchesEndpoint);
            if (_launchId != null)
            {
                link += $"/{_launchId.ToString().ToUpper()}";
            }

            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}