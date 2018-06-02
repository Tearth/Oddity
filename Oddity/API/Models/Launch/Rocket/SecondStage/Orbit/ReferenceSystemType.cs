using System.Runtime.Serialization;

namespace Oddity.API.Models.Launch.Rocket.SecondStage.Orbit
{
    public enum ReferenceSystemType
    {
        [EnumMember(Value = "geocentric")]
        Geocentric,

        [EnumMember(Value = "heliocentric")]
        Heliocentric,

        [EnumMember(Value = "highly-elliptical")]
        HighlyElliptical
    }
}
