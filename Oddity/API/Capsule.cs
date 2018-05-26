using System.Net.Http;
using Oddity.API.Builders.Capsule;

namespace Oddity.API
{
    public class Capsule
    {
        private HttpClient _httpClient;

        public Capsule(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public CapsuleBuilder GetAbout()
        {
            return new CapsuleBuilder(_httpClient);
        }

        public AllCapsulesBuilder GetAll()
        {
            return new AllCapsulesBuilder(_httpClient);
        }
    }
}
