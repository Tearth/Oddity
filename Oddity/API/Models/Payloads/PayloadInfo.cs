using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oddity.API.Models.Payloads
{
    public class PayloadInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? Reused { get; set; }

        [JsonProperty("launch")]
        public string LaunchId { get; set; }

        public List<string> Customers { get; set; }
        public DragonInfo Dragon { get; set; }

        [JsonProperty("norad_ids")]
        public List<uint> NoradIds { get; set; }

        public List<string> Nationalities { get; set; }
        public List<string> Manufacturers { get; set; }

        [JsonProperty("mass_kg")]
        public double? MassKilograms { get; set; }

        [JsonProperty("mass_lbs")]
        public double? MassPounds { get; set; }

        public string Orbit { get; set; }

        [JsonProperty("reference_system")]
        public string ReferenceSystem { get; set; }

        public string Regime { get; set; }
        public double? Longitude { get; set; }

        [JsonProperty("semi_major_axis_km")]
        public double? SemiMajorAxisKilometers { get; set; }

        public double? Eccentricity { get; set; }

        [JsonProperty("periapsis_km")]
        public double? PeriapsisKilometers { get; set; }

        [JsonProperty("apoapsis_km")]
        public double? ApoapsisKilometers { get; set; }

        [JsonProperty("inclination_deg")]
        public double? InclinationDegrees { get; set; }

        [JsonProperty("period_min")]
        public double? PeriodMinutes { get; set; }

        [JsonProperty("lifespan_years")]
        public uint? LifespanYears { get; set; }

        public DateTime? Epoch { get; set; }

        [JsonProperty("mean_motion")]
        public double? MeanMotion { get; set; }

        public double? Raan { get; set; }

        [JsonProperty("arg_of_pericenter")]
        public double? ArgOfPericenter { get; set; }

        [JsonProperty("mean_anomaly")]
        public double? MeanAnomaly { get; set; }
    }
}
