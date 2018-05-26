using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launch.Rocket
{
    public class TelemetryInfo
    {
        [JsonProperty("flight_club")]
        public string FlightClub { get; set; }
    }
}
