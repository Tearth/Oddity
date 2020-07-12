using System;
using Oddity.API.Models.Query;

namespace Oddity.API.Events
{
    /// <summary>
    /// Contains OnRequestSend event arguments.
    /// </summary>
    public class RequestSendEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the URL which has been called to retrieve the specified data.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the query used to filter data.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestSendEventArgs"/> class.
        /// </summary>
        /// <param name="url">The URL which has been called to retrieve the specified data.</param>
        public RequestSendEventArgs(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestSendEventArgs"/> class.
        /// </summary>
        /// <param name="url">The URL which has been called to retrieve the specified data.</param>
        /// <param name="query">The query used to filter data.</param>
        public RequestSendEventArgs(string url, string query)
        {
            Url = url;
            Query = query;
        }
    }
}
