using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Oddity.API.Models.Capsule.Payload
{
    public class TrunkInfo
    {
        [JsonProperty("trunk_volume")]
        public PayloadVolumeInfo TrunkVolume { get; set; }

        public CargoInfo Cargo { get; set; }
    }
}
