using System.Net.Http;
using Oddity.API.Builders.Capsule;
using Oddity.API.Builders.Rocket;

namespace Oddity.API
{
    public class Capsule
    {
        private HttpClient _httpClient;

        public Capsule(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public CapsuleBuilder GetInfo()
        {
            return new CapsuleBuilder(_httpClient);
        }

        public AllCapsulesBuilder GetInfoAboutAll()
        {
            return new AllCapsulesBuilder(_httpClient);
        }
    }
}
