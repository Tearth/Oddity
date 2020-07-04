using System.Runtime.Serialization;

namespace Oddity.API.Models.Capsule
{
    public enum CapsuleStatus
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
