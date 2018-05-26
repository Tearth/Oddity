using System.Runtime.Serialization;

namespace Oddity.API.Models.Launch.Rocket.FirstStage
{
    public enum LandingType
    {
        [EnumMember(Value = "ASDS")]
        ASDS,

        [EnumMember(Value = "RTLC")]
        RTLS,

        [EnumMember(Value = "Ocean")]
        Ocean
    }
}
