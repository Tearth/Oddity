namespace Oddity.Models.Common
{
    public class SizeInfo : ModelBase
    {
        public double? Meters { get; set; }
        public double? Feet { get; set; }

        public override string ToString()
        {
            return $"{Meters} m ({Feet} ft)";
        }
    }
}
