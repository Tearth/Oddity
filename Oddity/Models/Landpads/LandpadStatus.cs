using System.Runtime.Serialization;

namespace Oddity.Models.Landpads
{
    public enum LandpadStatus
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
