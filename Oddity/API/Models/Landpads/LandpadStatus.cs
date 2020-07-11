using System.Runtime.Serialization;

namespace Oddity.API.Models.Landpads
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
