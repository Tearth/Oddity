using System;
using System.Net;

namespace Oddity.API.Events
{
    /// <summary>
    /// Contains OnResponseReceive event arguments.
    /// </summary>
    public class ResponseReceiveEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the raw response from the SpaceX API server.
        /// </summary>
        public string Response { get; }

        /// <summary>
        /// Gets the response status code (200 = OK).
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the reason phrase (useful when error has occurred).
        /// </summary>
        public string ReasonPhrase { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseReceiveEventArgs"/> class.
        /// </summary>
        /// <param name="response">The raw response from the SpaceX API server.</param>
        /// <param name="statusCode">The response status code returned from the API.</param>
        /// <param name="reasonPhrase">The reason phrase returned from the API.</param>
        public ResponseReceiveEventArgs(string response, HttpStatusCode statusCode, string reasonPhrase)
        {
            Response = response;
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
        }
    }
}
