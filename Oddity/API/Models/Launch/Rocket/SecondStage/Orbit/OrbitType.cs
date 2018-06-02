using System.Runtime.Serialization;

namespace Oddity.API.Models.Launch.Rocket.SecondStage.Orbit
{
    public enum OrbitType
    {
        [EnumMember(Value = "PO")]
        PO,

        [EnumMember(Value = "LEO")]
        LEO,

        [EnumMember(Value = "ISS")]
        ISS,

        [EnumMember(Value = "GTO")]
        GTO,

        [EnumMember(Value = "SSO")]
        SSO,

        [EnumMember(Value = "HCO")]
        HCO,

        [EnumMember(Value = "HEO")]
        HEO,

        [EnumMember(Value = "ES-L1")]
        ESL1
    }
}
