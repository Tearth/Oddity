using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models;

namespace Oddity.API
{
    public class Company
    {
        private HttpClient _httpClient;

        private const string CompanyInfoEndpoint = "/v2/info";

        public Company(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompanyInfo> GetInfo()
        {
            var json = await _httpClient.GetStringAsync(ApiConfiguration.ApiEndpoint + CompanyInfoEndpoint);
            var deserialized = JsonConvert.DeserializeObject<CompanyInfo>(json);

            return deserialized;
        }
    }
}
