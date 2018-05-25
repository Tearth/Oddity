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

        public RocketBuilder GetInfo()
        {
            return new RocketBuilder(_httpClient);
        }

        public AllRocketsBuilder GetInfoAboutAll()
        {
            return new AllRocketsBuilder(_httpClient);
        }
    }
}
