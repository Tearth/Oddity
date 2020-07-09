using System;

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
        /// Initializes a new instance of the <see cref="RequestSendEventArgs"/> class.
        /// </summary>
        /// <param name="url">The URL which has been called to retrieve the specified data.</param>
        public RequestSendEventArgs(string url)
        {
            Url = url;
        }
    }
}
