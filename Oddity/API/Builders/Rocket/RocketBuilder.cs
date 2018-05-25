using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models.Rocket;

namespace Oddity.API.Builders.Rocket
{
    public class RocketBuilder : BuilderBase
    {
        private RocketType? _rocketType;
        private const string RocketInfoEndpoint = "rockets";

        public RocketBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        public RocketBuilder WithType(RocketType type)
        {
            _rocketType = type;
            return this;
        }

        public RocketInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        public async Task<RocketInfo> ExecuteAsync()
        {
            var link = BuildLink(RocketInfoEndpoint);
            if (_rocketType.HasValue)
            {
                link += $"/{_rocketType.ToString().ToLower()}";
            }

            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<RocketInfo>(json);
        }
    }
}
