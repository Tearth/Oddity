using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Exceptions;
using Oddity.API.Models.Company;

namespace Oddity.API.Builders.Company
{
    /// <summary>
    /// Represents a set of methods to filter history events and download them from API.
    /// </summary>
    public class HistoryBuilder : BuilderBase
    {
        private const string CompanyHistoryEndpoint = "info/history";

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
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
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public List<HistoryEvent> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The list of history events.</returns>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public async Task<List<HistoryEvent>> ExecuteAsync()
        {
            var link = BuildLink(CompanyHistoryEndpoint);
            return await RequestForObject<List<HistoryEvent>>(link);
        }
    }
}
