using System.Runtime.Serialization;

namespace Oddity.API.Models.Launch
{
    public enum TentativeMaxPrecision
    {
        [EnumMember(Value = "hour")]
        Hour,

        [EnumMember(Value = "day")]
        Day,

        [EnumMember(Value = "month")]
        Month,

        [EnumMember(Value = "quarter")]
        Quarter,

        [EnumMember(Value = "half")]
        Half,

        [EnumMember(Value = "year")]
        Year
    }
}
