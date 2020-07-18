using System.Net.Http;
using System.Threading.Tasks;
using Oddity.Cache;
using Oddity.Events;
using Oddity.Models;

namespace Oddity.Builders
{
    /// <summary>
    /// Represents a simple builder used to retrieve data without any filters.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public class SimpleBuilder<TReturn> : BuilderBase<TReturn> where TReturn : ModelBase, IIdentifiable
    {
        private readonly string _endpoint;
        private readonly string _id;
        private readonly CacheService<TReturn> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="cache"></param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public SimpleBuilder(OddityCore context, CacheService<TReturn> cache, string endpoint) 
            : this(context, cache, endpoint, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="cache"></param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="id">The ID of the specified object to retrieve from API.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public SimpleBuilder(OddityCore context, CacheService<TReturn> cache, string endpoint, string id) 
            : base(context)
        {
            _endpoint = endpoint;
            _id = id;
            _cache = cache;
        }

        /// <inheritdoc />
        public override TReturn Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override bool Execute(TReturn model)
        {
            return ExecuteAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override async Task<TReturn> ExecuteAsync()
        {
            if (Context.CacheEnabled && _cache.GetIfAvailable(out TReturn data, _id ?? _endpoint))
            {
                return data;
            }

            var content = await GetResponseFromEndpoint($"{_endpoint}/{_id}");
            if (content == null)
            {
                return null;
            }

            var deserializedObject = DeserializeJson(content);
            deserializedObject.SetContext(Context);

            if (Context.CacheEnabled)
            {
                _cache.Update(deserializedObject, _id ?? _endpoint);
            }

            return deserializedObject;
        }

        /// <inheritdoc />
        public override async Task<bool> ExecuteAsync(TReturn model)
        {
            var content = await GetResponseFromEndpoint($"{_endpoint}/{_id}");
            if (content == null)
            {
                return false;
            }

            DeserializeJson(content, model);
            model.SetContext(Context);

            return true;
        }
    }
}
