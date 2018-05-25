using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Oddity.API.Models.Launchpad
{
    public enum LaunchpadStatus
    {
        Retired,
        Active,

        [EnumMember(Value = "under construction")]
        UnderConstruction
    }
}
