using System.Runtime.Serialization;

namespace Oddity.API.Models.Capsule
{
    public enum CapsuleId
    {
        [EnumMember(Value = "dragon1")]
        Dragon1,

        [EnumMember(Value = "dragon2")]
        Dragon2,

        [EnumMember(Value = "crewdragon")]
        CrewDragon
    }
}
