using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Oddity.Events;
using Oddity.Exceptions;

namespace Oddity.Builders
{
    /// <summary>
    /// Represents an abstract base class for all builders.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public abstract class BuilderBase<TReturn>
    {
        protected readonly OddityCore Context;

        private readonly JsonSerializerSettings _serializationSettings;

        protected BuilderBase(OddityCore context)
        {
            Context = context;

            _serializationSettings = new JsonSerializerSettings
            {
                Error = JsonDeserializationError,
#if DEBUG
                CheckAdditionalContent = true,
                MissingMemberHandling = MissingMemberHandling.Error
#endif
            };
        }

        /// <summary>
        /// Performs an synchronous request to the API and returns deserialized JSON.
        /// </summary>
        /// <returns>The deserialized object retrieved from the API or null for non existing ID.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable and can't process any request.</exception>
        /// <exception cref="ApiBadRequestException">Thrown when SpaceX API received an invalid request which cannot be processed.</exception>
        public abstract TReturn Execute();

        /// <summary>
        /// Performs an synchronous request to the API and fills passed model in parameter with deserialized JSON.
        /// </summary>
        /// <param name="model">The model which will be filled with deserialized JSON.</param>
        /// <returns>The flag indicating if the API request and model fill has been done with success or not.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable and can't process any request.</exception>
        /// <exception cref="ApiBadRequestException">Thrown when SpaceX API received an invalid request which cannot be processed.</exception>
        public abstract bool Execute(TReturn model);

        /// <summary>
        /// Performs an asynchronous request to the API and returns deserialized JSON.
        /// </summary>
        /// <returns>The deserialized object retrieved from the API or null for non existing ID.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable and can't process any request.</exception>
        /// <exception cref="ApiBadRequestException">Thrown when SpaceX API received an invalid request which cannot be processed.</exception>
        public abstract Task<TReturn> ExecuteAsync();

        /// <summary>
        /// Performs an asynchronous request to the API and fills passed model in parameter with deserialized JSON.
        /// </summary>
        /// <param name="model">The model which will be filled with deserialized JSON.</param>
        /// <returns>The flag indicating if the API request and model fill has been done with success or not.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable and can't process any request.</exception>
        /// <exception cref="ApiBadRequestException">Thrown when SpaceX API received an invalid request which cannot be processed.</exception>
        public abstract Task<bool> ExecuteAsync(TReturn model);

        protected async Task<string> GetResponseFromEndpoint(string link, string postBody = null)
        {
            Context.BuilderDelegates.RequestSend(new RequestSendEventArgs(link, postBody));
            if (Context.StatisticsEnabled)
            {
                Context.Statistics.RequestsMade++;
            }

            HttpResponseMessage response;
            if (postBody == null)
            {
                response = await Context.HttpClient.GetAsync(link).ConfigureAwait(false);
            }
            else
            {
                var httpContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                response = await Context.HttpClient.PostAsync(link, httpContent).ConfigureAwait(false);
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var eventArgs = new ResponseReceiveEventArgs(content, response.StatusCode, response.ReasonPhrase);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                    {
                        return null;
                    }
                    case HttpStatusCode.BadRequest:
                    {
                        throw new ApiBadRequestException(content);
                    }
                    default:
                    {
                        throw new ApiUnavailableException($"Status code: {(int)response.StatusCode}");
                    }
                }
            }

            Context.BuilderDelegates.ResponseReceived(eventArgs);
            if (Context.StatisticsEnabled)
            {
                Context.Statistics.ResponsesReceived++;
            }

            return content;
        }

        protected string SerializeJson(object model)
        {
            return JsonConvert.SerializeObject(model);
        }

        protected TReturn DeserializeJson(string content)
        {
            return JsonConvert.DeserializeObject<TReturn>(content, _serializationSettings);
        }

        protected void DeserializeJson(string content, TReturn model)
        {
            JsonConvert.PopulateObject(content, model, _serializationSettings);
        }

        private void JsonDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Context.BuilderDelegates.DeserializationError(errorEventArgs);
        }
    }
}
