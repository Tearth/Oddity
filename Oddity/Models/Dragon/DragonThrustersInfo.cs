using Newtonsoft.Json;
using Oddity.Models.Common;

namespace Oddity.Models.Dragon
{
    public class DragonThrustersInfo : ModelBase
    {
        public string Type { get; set; }
        public uint? Amount { get; set; }
        public uint? Pods { get; set; }
        public uint? Isp { get; set; }

        public ThrustInfo Thrust { get; set; }

        [JsonProperty("fuel_1")]
        public string FirstFuel { get; set; }
        
        [JsonProperty("fuel_2")]
        public string SecondFuel { get; set; }
    }
}
