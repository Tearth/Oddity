using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Oddity.API.Models.Launch.Rocket.SecondStage
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

        [EnumMember(Value = "ES-L1")]
        ESL1
    }
}
