using System;
using System.Collections.Generic;

namespace Oddity.API.Builders
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
        /// Gets the dictionary of filters which has been applied.
        /// </summary>
        public Dictionary<string, string> Filteres { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestSendEventArgs"/> class.
        /// </summary>
        /// <param name="url">The URL which has been called to retrieve the specified data.</param>
        /// <param name="filters">The dictionary of filters which has been applied.</param>
        public RequestSendEventArgs(string url, Dictionary<string, string> filters)
        {
            Url = url;
            Filteres = filters;
        }
    }
}
