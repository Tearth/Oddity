using Newtonsoft.Json.Serialization;

namespace Oddity.Events
{
    public delegate void DeserializationError(ErrorEventArgs args);
    public delegate void RequestSend(RequestSendEventArgs args);
    public delegate void ResponseReceived(ResponseReceiveEventArgs args);

    /// <summary>
    /// Container for all delegates invoked during processing a request.
    /// </summary>
    public class BuilderDelegatesContainer
    {
        /// <summary>
        /// Delegate invoked when there was an error during JSON deserialization.
        /// </summary>
        public DeserializationError DeserializationError { get; set; }

        /// <summary>
        /// Delegate invoked just before request send.
        /// </summary>
        public RequestSend RequestSend { get; set; }

        /// <summary>
        /// Delegate invoked after response receive.
        /// </summary>
        public ResponseReceived ResponseReceived { get; set; }
    }
}
