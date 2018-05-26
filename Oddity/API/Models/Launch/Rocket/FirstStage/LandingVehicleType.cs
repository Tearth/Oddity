using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Oddity.API.Models.Launch.Rocket
{
    public enum LandingVehicleType
    {
        [EnumMember(Value = "OCISLY")]
        OCISLY,

        [EnumMember(Value = "JRTI")]
        JRTI,

        [EnumMember(Value = "LZ-1")]
        LZ1
    }
}
