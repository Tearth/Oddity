using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
        Unknown,
    }
}
