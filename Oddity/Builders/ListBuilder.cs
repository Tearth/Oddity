using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.Cache;
using Oddity.Events;
using Oddity.Models;

namespace Oddity.Builders
{
    /// <summary>
    /// Represents a list builder used to retrieve data (collection of objects) without any filters.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public class ListBuilder<TReturn> : BuilderBase<List<TReturn>> where TReturn : ModelBase, IIdentifiable
    {
        private readonly string _endpoint;
        private readonly CacheService<TReturn> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public ListBuilder(string endpoint, OddityCore context, CacheService<TReturn> cache)
            : base(context)
        {
            _endpoint = endpoint;
            _cache = cache;
        }

        /// <inheritdoc />
        public override List<TReturn> Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override bool Execute(List<TReturn> model)
        {
            return ExecuteAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override async Task<List<TReturn>> ExecuteAsync()
        {
            if (Context.CacheEnabled && _cache.GetListIfAvailable(out List<TReturn> list, _endpoint))
            {
                return list;
            }

            var content = await GetResponseFromEndpoint($"{_endpoint}");
            var deserializedObjectsList = DeserializeJson(content);

            foreach (var deserializedObject in deserializedObjectsList)
            {
                deserializedObject.SetContext(Context);
            }

            if (Context.CacheEnabled)
            {
                _cache.UpdateList(deserializedObjectsList, _endpoint);
            }

            return deserializedObjectsList;
        }

        /// <inheritdoc />
        public override async Task<bool> ExecuteAsync(List<TReturn> models)
        {
            var content = await GetResponseFromEndpoint($"{_endpoint}");
            if (content == null)
            {
                return false;
            }

            DeserializeJson(content, models);

            foreach (var deserializedObject in models)
            {
                deserializedObject.SetContext(Context);
            }

            return true;
        }
    }
}
