using System.Net.Http;
using Oddity.API.Builders.Rocket;

namespace Oddity.API
{
    public class Rocket
    {
        private HttpClient _httpClient;

        public Rocket(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public RocketBuilder GetAbout()
        {
            return new RocketBuilder(_httpClient);
        }

        public AllRocketsBuilder GetAll()
        {
            return new AllRocketsBuilder(_httpClient);
        }
    }
}
