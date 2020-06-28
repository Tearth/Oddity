using System;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launch.Rocket.SecondStage.Orbit
{
    public class OrbitParameters
    {
        [JsonProperty("reference_system")]
        public ReferenceSystemType? ReferenceSystem { get; set; }

        public OrbitRegime? Regime { get; set; }
        public float? Longitude { get; set; }

        [JsonProperty("semi_major_axis_km")]
        public float? SemiMajorAxisKilometers { get; set; }

        public float? Eccentricity { get; set; }

        [JsonProperty("periapsis_km")]
        public float? PeriapsisKilometers { get; set; }

        [JsonProperty("apoapsis_km")]
        public float? ApoapsisKilometers { get; set; }

        [JsonProperty("inclination_deg")]
        public float? InclinationDegrees { get; set; }

        [JsonProperty("period_min")]
        public float? PeriodMinutes { get; set; }

        [JsonProperty("lifespan_years")]
        public float? LifespanYears { get; set; }

        public DateTime? Epoch { get; set; }

        [JsonProperty("mean_motion")]
        public float? MeanMotion { get; set; }

        [JsonProperty("raan")]
        public float? Raan { get; set; }

        [JsonProperty("arg_of_pericenter")]
        public float? ArgOfPericenter { get; set; }

        [JsonProperty("mean_anomaly")]
        public float? MeanAnomaly { get; set; }
    }
}
