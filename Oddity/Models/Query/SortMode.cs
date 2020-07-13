using System.Runtime.Serialization;

namespace Oddity.Models.Query
{
    public enum SortMode
    {
        Undefined = 0,

        [EnumMember(Value = "asc")]
        Ascending = 1,

        [EnumMember(Value = "desc")]
        Descending = -1
    }
}