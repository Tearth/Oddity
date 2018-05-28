using System.Runtime.Serialization;

namespace Oddity.API.Models.Rocket
{
    public enum RocketId
    {
        [EnumMember(Value = "falcon1")]
        Falcon1,

        [EnumMember(Value = "falcon9")]
        Falcon9,

        [EnumMember(Value = "falconheavy")]
        FalconHeavy,

        [EnumMember(Value = "bfr")]
        Bfr
    }
}
