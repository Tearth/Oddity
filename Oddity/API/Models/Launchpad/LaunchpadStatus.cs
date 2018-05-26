using System.Runtime.Serialization;

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
