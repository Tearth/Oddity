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

        public AllLaunchesBuilder GetAll()
        {
            return new AllLaunchesBuilder(_httpClient);
        }

        public LatestLaunchesBuilder GetLatest()
        {
            return new LatestLaunchesBuilder(_httpClient);
        }

        public NextLaunchesBuilder GetNext()
        {
            return new NextLaunchesBuilder(_httpClient);
        }

        public UpcomingLaunchesBuilder GetUpcoming()
        {
            return new UpcomingLaunchesBuilder(_httpClient);
        }
    }
}
