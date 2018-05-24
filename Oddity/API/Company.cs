using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models;
using Oddity.API.Models.Company;

namespace Oddity.API
{
    public class Company
    {
        private HttpClient _httpClient;

        private const string CompanyInfoEndpoint = "/v2/info";
        private const string CompanyHistoryEndpoint = "/v2/info/history";

        public Company(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompanyInfo> GetInfo()
        {
            var json = await _httpClient.GetStringAsync(ApiConfiguration.ApiEndpoint + CompanyInfoEndpoint);
            return JsonConvert.DeserializeObject<CompanyInfo>(json);
        }

        public async Task<List<HistoryEvent>> GetHistory()
        {
            var json = await _httpClient.GetStringAsync(ApiConfiguration.ApiEndpoint + CompanyHistoryEndpoint);

            // Temporary workaround for invalid date returned from API (day 00 doesn't exist so DateTime was throwing exception during parsing).
            json = json.Replace("00T", "01T");

            return JsonConvert.DeserializeObject<List<HistoryEvent>>(json);
        }
    }
}
