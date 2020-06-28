using System.Collections.Generic;

namespace Oddity.API.Models.Launch.Rocket.SecondStage
{
    public class SecondStageInfo
    {
        public int? Block { get; set; }
        public List<PayloadInfo> Payloads { get; set; }
    }
}
