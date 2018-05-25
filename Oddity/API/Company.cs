using System.Net.Http;
using Oddity.API.Builders.Company;

namespace Oddity.API
{
    public class Company
    {
        private HttpClient _httpClient;

        public Company(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public InfoBuilder GetInfo()
        {
            return new InfoBuilder(_httpClient);
        }

        public HistoryBuilder GetHistory()
        {
            return new HistoryBuilder(_httpClient);
        }
    }
}
