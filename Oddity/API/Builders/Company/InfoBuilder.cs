using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Company;

namespace Oddity.API.Builders.Company
{
    /// <summary>
    /// Represents a set of methods to filter company information and download them from API.
    /// </summary>
    public class InfoBuilder : BuilderBase<CompanyInfo>
    {
        private const string CompanyInfoEndpoint = "info";

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public InfoBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <inheritdoc />
        protected override async Task<CompanyInfo> ExecuteBuilder()
        {
            var link = BuildLink(CompanyInfoEndpoint);
            return await SendRequestToApi(link);
        }
    }
}
