using System.Net.Http;
using Oddity.API.Builders.Launches;
using Oddity.API.Builders.Launchpad;
using Oddity.API.Builders.Rocket;

namespace Oddity.API
{
    public class Launches
    {
        private HttpClient _httpClient;

        public Launches(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public AllLaunchesBuilder GetInfoAboutAll()
        {
            return new AllLaunchesBuilder(_httpClient);
        }
    }
}
