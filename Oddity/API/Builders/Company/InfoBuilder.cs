using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Company;

namespace Oddity.API.Builders.Company
{
    /// <summary>
    /// Represents a set of methods to filter company information and download them from API.
    /// </summary>
    public class InfoBuilder : BuilderBase
    {
        private const string CompanyInfoEndpoint = "info";

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public InfoBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The company information.</returns>
        public CompanyInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The company information.</returns>
        public async Task<CompanyInfo> ExecuteAsync()
        {
            var link = BuildLink(CompanyInfoEndpoint);
            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<CompanyInfo>(json);
        }
    }
}
