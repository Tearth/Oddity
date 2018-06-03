using Newtonsoft.Json.Serialization;

namespace Oddity.API.Builders
{
    public delegate void DeserializationError(ErrorEventArgs args);

    public class BuilderDelegatesContainer
    {
        public DeserializationError DeserializationError { get; set; }
    }
}
