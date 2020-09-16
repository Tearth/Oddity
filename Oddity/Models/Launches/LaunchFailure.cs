namespace Oddity.Models.Launches
{
    public class LaunchFailure : ModelBase
    {
        public int? Time { get; set; }
        public uint? Altitude { get; set; }
        public string Reason { get; set; }
    }
}
