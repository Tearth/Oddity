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

        /// <summary>
        /// Filters history events by date range (both "from" and "to" dates have to be present). Note that you have to call
        /// <see cref="Execute"/> or <see cref="ExecuteAsync"/> to get result from the API. Every next call of this method will
        /// override previously saved date range filter.
        /// </summary>
        /// <param name="from">Filter from the specified date.</param>
        /// <param name="to">Filter to the specified date.</param>
        /// <returns>The history builder.</returns>
        public HistoryBuilder WithRange(DateTime from, DateTime to)
        {
            AddFilter("start", from);
            AddFilter("end", to);
            return this;
        }

        /// <summary>
        /// Filters history events by flight number. Note that you have to call <see cref="Execute"/> or
        /// <see cref="ExecuteAsync"/> to get result from the API. Every next call of this method will
        /// override previously saved flight number filter.
        /// </summary>
        /// <param name="flightNumber">The flight number.</param>
        /// <returns>The history builder.</returns>
        public HistoryBuilder WithFlightNumber(int flightNumber)
        {
            AddFilter("order", flightNumber);
            return this;
        }

        /// <summary>
        /// Sorts history events ascending. Note that you have to call <see cref="Execute"/> or <see cref="ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved ordering filter.
        /// </summary>
        /// <returns>The history builder.</returns>
        public HistoryBuilder Ascending()
        {
            AddFilter("order", "asc");
            return this;
        }

        /// <summary>
        /// Sorts history events descending. Note that you have to call <see cref="Execute"/> or <see cref="ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved ordering filter.
        /// </summary>
        /// <returns>The history builder.</returns>
        public HistoryBuilder Descending()
        {
            AddFilter("order", "desc");
            return this;
        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The list of history events.</returns>
        public List<HistoryEvent> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The list of history events.</returns>
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
