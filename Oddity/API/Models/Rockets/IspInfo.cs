﻿using Newtonsoft.Json;

namespace Oddity.API.Models.Rockets
{
    public class IspInfo
    {
        [JsonProperty("sea_level")]
        public uint? SeaLevel { get; set; }

        public uint? Vacuum { get; set; }
    }
}