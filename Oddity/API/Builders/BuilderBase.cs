using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Oddity.API.Exceptions;

namespace Oddity.API.Builders
{
    /// <summary>
    /// Represents an abstract base class for all builders.
    /// </summary>
    public abstract class BuilderBase<TReturn>
    {
        protected readonly BuilderDelegatesContainer BuilderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderBase{TReturn}"/> class.
        /// </summary>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        protected BuilderBase(BuilderDelegatesContainer builderDelegatesContainer)
        {
            BuilderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Performs an request to the API with the specified parameters (if specified earlier).
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public abstract TReturn Execute();

        /// <summary>
        /// Performs an async request to the API with the specified parameters (if specified earlier).
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public abstract Task<TReturn> ExecuteAsync();

        protected TReturn DeserializeJson(string content)
        {
            var deserializationSettings = new JsonSerializerSettings { Error = JsonDeserializationError };
            return JsonConvert.DeserializeObject<TReturn>(content, deserializationSettings);
        }

        private void JsonDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            BuilderDelegatesContainer.DeserializationError(errorEventArgs);
        }
    }
}
