using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.API.Exceptions;

namespace Oddity.API.Builders
{
    /// <summary>
    /// Represents an abstract base class for all builders.
    /// </summary>
    public abstract class BuilderBase
    {
        protected HttpClient HttpClient;
        private Dictionary<string, string> _filters;

        protected BuilderBase(HttpClient httpClient)
        {
            HttpClient = httpClient;
            _filters = new Dictionary<string, string>();
        }

        protected void AddFilter(string name, int value)
        {
            _filters[name] = value.ToString();
        }

        protected void AddFilter(string name, string value)
        {
            _filters[name] = value;
        }

        protected void AddFilter(string name, bool value)
        {
            _filters[name] = value.ToString().ToLower();
        }

        protected void AddFilter(string name, DateTime value)
        {
            _filters[name] = value.ToString("yyyy-MM-dd");
        }

        protected string BuildLink(string endpoint)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(ApiConfiguration.ApiEndpoint);
            stringBuilder.Append("/");
            stringBuilder.Append(endpoint);

            var filters = SerializeFilters();
            if (!string.IsNullOrEmpty(filters))
            {
                stringBuilder.Append("?");
                stringBuilder.Append(filters);
            }

            return stringBuilder.ToString();
        }

        protected async Task<T> RequestForObject<T>(string link)
        {
            var response = await HttpClient.GetAsync(link);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new APIUnavailableException($"Status code: {(int)response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        private string SerializeFilters()
        {
            var stringBuilder = new StringBuilder();
            var first = true;

            foreach (var filter in _filters)
            {
                if (!first)
                {
                    stringBuilder.Append("&");
                }

                stringBuilder.Append($"{filter.Key}={filter.Value}");
                first = false;
            }

            return stringBuilder.ToString();
        }
    }
}
