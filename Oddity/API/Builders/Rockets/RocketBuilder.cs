using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Rocket;

namespace Oddity.API.Builders.Rockets
{
    /// <summary>
    /// Represents a set of methods to filter rocket information and download them from API.
    /// </summary>
    public class RocketBuilder : BuilderBase<RocketInfo>
    {
        private RocketId? _rocketType;
        private const string RocketInfoEndpoint = "rockets";

        /// <summary>
        /// Initializes a new instance of the <see cref="RocketBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public RocketBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Filters rocket information by the specified rocket type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or
        /// <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get result from the API. Every next call of this method will override previously saved rocket type filter.
        /// </summary>
        /// <param name="type">The rocket type (Falcon1, Falcon9, etc).</param>
        /// <returns>The rocket builder.</returns>
        public RocketBuilder WithType(RocketId type)
        {
            _rocketType = type;
            return this;
        }

        /// <inheritdoc />
        protected override async Task<RocketInfo> ExecuteBuilder()
        {
            var link = BuildLink(RocketInfoEndpoint);
            if (_rocketType.HasValue)
            {
                link += $"/{_rocketType.ToString().ToLower()}";
            }

            return await SendRequestToApi(link);
        }
    }
}
