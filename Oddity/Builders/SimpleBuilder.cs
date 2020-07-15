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
    public class SimpleBuilder<TReturn> : BuilderBase<TReturn> where TReturn : ModelBase
    {
        private readonly string _endpoint;
        private readonly string _id;
        private readonly OddityCore _context;
        private readonly CacheService<TReturn> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public SimpleBuilder(HttpClient httpClient, string endpoint, OddityCore context, CacheService<TReturn> cache, BuilderDelegates builderDelegates) 
            : this(httpClient, endpoint, null, context, cache, builderDelegates)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="id">The ID of the specified object to retrieve from API.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public SimpleBuilder(HttpClient httpClient, string endpoint, string id, OddityCore context, CacheService<TReturn> cache, BuilderDelegates builderDelegates) 
            : base(httpClient, builderDelegates)
        {
            _endpoint = endpoint;
            _id = id;
            _context = context;
            _cache = cache;
        }

        /// <inheritdoc />
        public override TReturn Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override void Execute(TReturn model)
        {
            ExecuteAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override async Task<TReturn> ExecuteAsync()
        {
            if (_context.CacheEnabled && _cache.GetIfAvailable(out TReturn data, _id))
            {
                return data;
            }

            var content = await GetResponseFromEndpoint($"{_endpoint}/{_id}");
            var deserializedObject = DeserializeJson(content);
            deserializedObject.SetContext(_context);

            if (_context.CacheEnabled)
            {
                _cache.Update(deserializedObject, _id);
            }

            return deserializedObject;
        }

        /// <inheritdoc />
        public override async Task ExecuteAsync(TReturn model)
        {
            var content = await GetResponseFromEndpoint($"{_endpoint}/{_id}");
            DeserializeJson(content, model);
            model.SetContext(_context);
        }
    }
}
