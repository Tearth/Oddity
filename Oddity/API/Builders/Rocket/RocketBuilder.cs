using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models.Company;
using Oddity.API.Models.Rocket;

namespace Oddity.API.Builders.Rocket
{
    public class RocketBuilder : BuilderBase
    {
        private const string RocketInfoEndpoint = "rockets";

        public RocketBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        public List<RocketInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        public async Task<List<RocketInfo>> ExecuteAsync()
        {
            var link = BuildLink(RocketInfoEndpoint);
            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<List<RocketInfo>>(json);
        }
    }
}
