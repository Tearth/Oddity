using System.Net.Http;
using Oddity.API.Builders.Launchpad;

namespace Oddity.API
{
    public class Launchpad
    {
        private HttpClient _httpClient;

        public Launchpad(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public LaunchpadBuilder GetInfo()
        {
            return new LaunchpadBuilder(_httpClient);
        }

        public AllLaunchpadsBuilder GetInfoAboutAll()
        {
            return new AllLaunchpadsBuilder(_httpClient);
        }
    }
}
