using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Ships
{
    public class ShipInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }

        [JsonProperty("legacy_id")]
        public string LegacyId { get; set; }

        public string Model { get; set; }
        public string Type { get; set; }
        public List<string> Roles { get; set; }

        public uint? Imo { get; set; }
        public uint? Mmsi { get; set; }
        public uint? Abs { get; set; }
        public uint? Class { get; set; }

        [JsonProperty("mass_kg")]
        public double? MassKilograms { get; set; }

        [JsonProperty("mass_lbs")]
        public double? MassPounds { get; set; }

        [JsonProperty("year_built")]
        public uint? YearBuilt { get; set; }

        [JsonProperty("home_port")]
        public string HomePort { get; set; }

        public string Status { get; set; }

        [JsonProperty("speed_kn")]
        public double? SpeedKnots { get; set; }

        [JsonProperty("course_deg")]
        public double? CourseDegrees { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [JsonProperty("last_ais_update")]
        public DateTime? LastAisUpdate { get; set; }

        public string Link { get; set; }
        public string Image { get; set; }

        [JsonProperty("launches")]
        public List<string> LaunchesId { get; set; }
    }
}
