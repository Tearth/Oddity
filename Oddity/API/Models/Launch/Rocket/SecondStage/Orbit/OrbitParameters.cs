using System;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launch.Rocket.SecondStage.Orbit
{
    public class OrbitParameters
    {
        [JsonProperty("reference_system")]
        public ReferenceSystemType? ReferenceSystem { get; set; }

        public OrbitRegime? Regime { get; set; }
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
        public double? LifespanYears { get; set; }

        public DateTime? Epoch { get; set; }

        [JsonProperty("mean_motion")]
        public double? MeanMotion { get; set; }

        [JsonProperty("raan")]
        public double? Raan { get; set; }

        [JsonProperty("arg_of_pericenter")]
        public double? ArgOfPericenter { get; set; }

        [JsonProperty("mean_anomaly")]
        public double? MeanAnomaly { get; set; }
    }
}
