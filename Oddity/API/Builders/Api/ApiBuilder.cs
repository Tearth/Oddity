using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Api;

namespace Oddity.API.Builders.Api
{
    /// <summary>
    /// Represents a set of methods to retrieve API information.
    /// </summary>
    public class ApiBuilder : BuilderBase<ApiInfo>
    {
        private const string ApiEndpoint = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="Builders.Api.ApiBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public ApiBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <inheritdoc />
        protected override async Task<ApiInfo> ExecuteBuilder()
        {
            var link = BuildLink(ApiEndpoint);
            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
