using System.Runtime.Serialization;

namespace Oddity.Models.Launchpads
{
    public enum LaunchpadStatus
    {
        Unknown,
        Active,
        Inactive,
        Retired,
        Lost,

        [EnumMember(Value = "under construction")]
        UnderConstruction
    }
}
