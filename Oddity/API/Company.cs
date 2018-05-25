using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Builders;
using Oddity.API.Models;
using Oddity.API.Models.Company;

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
            return JsonConvert.DeserializeObject<CompanyInfo>(json);
        }

        public HistoryBuilder GetHistory()
        {
            return new HistoryBuilder(_httpClient);
        }
    }
}
