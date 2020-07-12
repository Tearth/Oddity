using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Events;
using Oddity.API.Models;

namespace Oddity.API.Builders
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

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public SimpleBuilder(HttpClient httpClient, string endpoint, OddityCore context, BuilderDelegatesContainer builderDelegates) 
            : this(httpClient, endpoint, null, context, builderDelegates)
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
        public SimpleBuilder(HttpClient httpClient, string endpoint, string id, OddityCore context, BuilderDelegatesContainer builderDelegates) 
            : base(httpClient, builderDelegates)
        {
            _endpoint = endpoint;
            _id = id;
            _context = context;
        }

        /// <inheritdoc />
        public override TReturn Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override async Task<TReturn> ExecuteAsync()
        {
            var content = await GetResponseFromEndpoint($"{_endpoint}/{_id}");
            var deserializedObject = DeserializeJson(content);
            deserializedObject.SetContext(_context);

            return deserializedObject;
        }
    }
}
