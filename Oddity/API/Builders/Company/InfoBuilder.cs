using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models;
using Oddity.API.Models.Company;

namespace Oddity.API.Builders.Company
{
    public class InfoBuilder : BuilderBase
    {
        private const string CompanyInfoEndpoint = "info";

        public InfoBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        public CompanyInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        public async Task<CompanyInfo> ExecuteAsync()
        {
            var link = BuildLink(CompanyInfoEndpoint);
            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<CompanyInfo>(json);
        }
    }
}
