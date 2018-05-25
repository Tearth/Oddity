using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Oddity.API.Models.Common;

namespace Oddity.API.Models.Capsule.Payload
{
    public class TrunkInfo
    {
        [JsonProperty("trunk_volume")]
        public VolumeInfo TrunkVolume { get; set; }

        public CargoInfo Cargo { get; set; }
    }
}
