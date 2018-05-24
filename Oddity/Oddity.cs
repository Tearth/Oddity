using System.Net.Http;
using Oddity.API;

namespace Oddity
{
    public class Oddity
    {
        public Company Company { get; }

        private HttpClient _httpClient;

        public Oddity()
        {
            _httpClient = new HttpClient();

            Company = new Company(_httpClient);
        }
    }
}
