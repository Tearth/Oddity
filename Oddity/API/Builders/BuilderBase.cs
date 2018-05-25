using System;
using System.Collections.Generic;
using System.Text;

namespace Oddity.API.Builders
{
    public abstract class BuilderBase
    {
        private Dictionary<string, string> Filters;

        protected BuilderBase()
        {
            Filters = new Dictionary<string, string>();
        }

        protected void AddFilter(string name, int value)
        {
            Filters[name] = value.ToString();
        }

        protected void AddFilter(string name, string value)
        {
            Filters[name] = value;
        }

        protected void AddFilter(string name, DateTime value)
        {
            Filters[name] = value.ToString("yyyy-MM-dd");
        }

        protected string BuildLink(string endpoint)
        {
            return $"{ApiConfiguration.ApiEndpoint}/{endpoint}?{SerializeFilters()}";
        }

        private string SerializeFilters()
        {
            var stringBuilder = new StringBuilder();
            var first = true;

            foreach (var filter in Filters)
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
