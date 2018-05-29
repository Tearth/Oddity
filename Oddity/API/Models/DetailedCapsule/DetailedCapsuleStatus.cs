using System.Runtime.Serialization;

namespace Oddity.API.Models.DetailedCapsule
{
    public enum DetailedCapsuleStatus
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "destroyed")]
        Destroyed,

        [EnumMember(Value = "retired")]
        Retired,

        [EnumMember(Value = "unknown")]
        Unknown
    }
}
