using System.Runtime.Serialization;

namespace Oddity.API.Models.Launch.Rocket.SecondStage.Orbit
{
    public enum OrbitRegime
    {
        [EnumMember(Value = "low-earth")]
        LowEarth,

        [EnumMember(Value = "high-earth")]
        HighEarth,

        [EnumMember(Value = "geostationary")]
        Geostationary,

        [EnumMember(Value = "geosynchronous")]
        Geosynchronous,

        [EnumMember(Value = "L1-point")]
        L1Point,

        [EnumMember(Value = "sun-synchronous")]
        SunSynchronous,

        [EnumMember(Value = "sub-orbital")]
        SubOrbital
    }
}
