using System.Runtime.Serialization;

namespace Oddity.API.Models.Launchpad
{
    public enum LaunchpadType
    {
        [EnumMember(Value = "kwajalein_atoll")]
        KwajaleinAtoll,

        [EnumMember(Value = "ccafs_slc_40")]
        CcafsSlc40,

        [EnumMember(Value = "ccafs_lc_13")]
        CcafsLc13,

        [EnumMember(Value = "ksc_lc_39a")]
        KscLc39a,

        [EnumMember(Value = "vafb_slc_3w")]
        VafbSlc3w,

        [EnumMember(Value = "vafb_slc_4e")]
        VafbSlc4e,

        [EnumMember(Value = "vafb_slc_4w")]
        VafbSlc4w,

        [EnumMember(Value = "stls")]
        Stls
    }
}
