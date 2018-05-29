using System.Runtime.Serialization;

namespace Oddity.API.Models.DetailedCore
{
    public enum DetailedCoreStatus
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "destroyed")]
        Destroyed,

        [EnumMember(Value = "expended")]
        Expended,

        [EnumMember(Value = "retired")]
        Retired,

        [EnumMember(Value = "unknown")]
        Unknown,
    }
}
