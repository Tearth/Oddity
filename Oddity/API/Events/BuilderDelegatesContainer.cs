using Newtonsoft.Json.Serialization;

namespace Oddity.API.Builders
{
    public delegate void DeserializationError(ErrorEventArgs args);
    public delegate void RequestSend(RequestSendEventArgs args);
    public delegate void ResponseReceived(ResponseReceiveEventArgs args);

    public class BuilderDelegatesContainer
    {
        public DeserializationError DeserializationError { get; set; }
        public RequestSend RequestSend { get; set; }
        public ResponseReceived ResponseReceived { get; set; }
    }
}
