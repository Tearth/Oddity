using Oddity.API.Models.Common;

namespace Oddity.API.Models.Rockets
{
    public class FairingInfo : ModelBase
    {
        public SizeInfo Height { get; set; }
        public SizeInfo Diameter { get; set; }
    }
}
