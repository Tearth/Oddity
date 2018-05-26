using System.Runtime.Serialization;

namespace Oddity.API.Models.Launch.Rocket.FirstStage
{
    public enum LandingVehicleType
    {
        [EnumMember(Value = "OCISLY")]
        OCISLY,

        [EnumMember(Value = "JRTI")]
        JRTI,

        [EnumMember(Value = "LZ-1")]
        LZ1
    }
}
