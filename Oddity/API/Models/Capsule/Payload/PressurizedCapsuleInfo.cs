using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Oddity.API.Models.Capsule.Payload
{
    public class PressurizedCapsuleInfo
    {
        [JsonProperty("payload_volume")]
        public PayloadVolumeInfo PayloadVolume { get; set; }
    }
}
