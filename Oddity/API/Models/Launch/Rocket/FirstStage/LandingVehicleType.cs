using System.Runtime.Serialization;

namespace Oddity.API.Models.Launch.Rocket.FirstStage
{
    public enum LandingVehicleType
    {
        [EnumMember(Value = "OCISLY")]
        OCISLY,

        [EnumMember(Value = "JRTI")]
        JRTI,

        [EnumMember(Value = "JRTI-1")]
        JRTI_1,

        [EnumMember(Value = "LZ-1")]
        LZ1,

        [EnumMember(Value = "LZ-2")]
        LZ2,

        [EnumMember(Value = "LZ-3")]
        LZ3,

        [EnumMember(Value = "LZ-4")]
        LZ4
    }
}
