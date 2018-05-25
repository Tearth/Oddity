using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Models.Company;

namespace Oddity.API.Builders.Company
{
    public class HistoryBuilder : BuilderBase
    {
        private const string CompanyHistoryEndpoint = "info/history";

        public HistoryBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        public HistoryBuilder WithRange(DateTime from, DateTime to)
        {
            AddFilter("start", from);
            AddFilter("end", to);
            return this;
        }

        public HistoryBuilder WithFlightNumber(int flightNumber)
        {
            AddFilter("order", flightNumber);
            return this;
        }

        public HistoryBuilder Ascending()
        {
            AddFilter("order", "asc");
            return this;
        }

        public HistoryBuilder Descending()
        {
            AddFilter("order", "desc");
            return this;
        }

        public List<HistoryEvent> Execute()
        {
            return ExecuteAsync().Result;
        }

        public async Task<List<HistoryEvent>> ExecuteAsync()
        {
            var link = BuildLink(CompanyHistoryEndpoint);
            var json = await HttpClient.GetStringAsync(link);

            // Temporary workaround for invalid date returned from API (day 00 doesn't exist so DateTime was throwing exception during parsing).
            json = json.Replace("00T", "01T");

            return JsonConvert.DeserializeObject<List<HistoryEvent>>(json);
        }
    }
}
