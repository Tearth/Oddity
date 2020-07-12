using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oddity.API.Models.Launches;

namespace Oddity.API.Models.Payloads
{
    public class PayloadInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? Reused { get; set; }
        public string Orbit { get; set; }
        public string Regime { get; set; }
        public double? Longitude { get; set; }
        public double? Eccentricity { get; set; }
        public DateTime? Epoch { get; set; }
        public double? Raan { get; set; }

        public List<string> Customers { get; set; }
        public List<string> Nationalities { get; set; }
        public List<string> Manufacturers { get; set; }
        public DragonInfo Dragon { get; set; }

        [JsonProperty("norad_ids")]
        public List<uint> NoradIds { get; set; }

        [JsonProperty("mass_kg")]
        public double? MassKilograms { get; set; }

        [JsonProperty("mass_lbs")]
        public double? MassPounds { get; set; }

        [JsonProperty("reference_system")]
        public string ReferenceSystem { get; set; }

        [JsonProperty("semi_major_axis_km")]
        public double? SemiMajorAxisKilometers { get; set; }

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

        [JsonProperty("mean_motion")]
        public double? MeanMotion { get; set; }

        [JsonProperty("arg_of_pericenter")]
        public double? ArgOfPericenter { get; set; }

        [JsonProperty("mean_anomaly")]
        public double? MeanAnomaly { get; set; }

        [JsonProperty("launch")]
        public string LaunchId
        {
            get => _launchId;
            set
            {
                _launchId = value;
                Launch = new Lazy<LaunchInfo>(() => Context.LaunchesEndpoint.Get(_launchId).Execute());
            }
        }

        public Lazy<LaunchInfo> Launch { get; private set; }

        private string _launchId;
    }
}
