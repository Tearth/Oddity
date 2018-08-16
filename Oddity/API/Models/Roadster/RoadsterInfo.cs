using System;
using Newtonsoft.Json;

namespace Oddity.API.Models.Roadster
{
    public class RoadsterInfo
    {
        public string Name { get; set; }

        [JsonProperty("launch_date_utc")]
        public DateTime? DateTimeUtc { get; set; }

        [JsonProperty("launch_date_unix")]
        public ulong DateTimeUnix { get; set; }

        [JsonProperty("launch_mass_kg")]
        public uint LaunchMassKg { get; set; }

        [JsonProperty("launch_mass_lbs")]
        public uint LaunchMassLbs { get; set; }

        [JsonProperty("norad_id")]
        public uint NoradId { get; set; }

        [JsonProperty("epoch_jd")]
        public float EpochJs { get; set; }

        [JsonProperty("apoapsis_au")]
        public float ApoapsisAu { get; set; }

        [JsonProperty("periapsis_au")]
        public float PeriapsisAu { get; set; }

        [JsonProperty("semi_major_axis_au")]
        public float SemiMajorAxisAu { get; set; }

        public float Eccentricity { get; set; }
        public float Inclination { get; set; }
        public float Longitude { get; set; }

        [JsonProperty("periapsis_arg")]
        public float PeriapsisArg { get; set; }

        [JsonProperty("period_days")]
        public float PeriodDays { get; set; }

        [JsonProperty("speed_kph")]
        public float SpeedKph { get; set; }

        [JsonProperty("speed_mph")]
        public float SpeedMph { get; set; }

        [JsonProperty("earth_distance_km")]
        public float EarthDistanceKm { get; set; }

        [JsonProperty("earth_distance_mi")]
        public float EarthDistanceMi { get; set; }

        [JsonProperty("mars_distance_km")]
        public float MarsDistanceKm { get; set; }

        [JsonProperty("mars_distance_mi")]
        public float MarsDistanceMi { get; set; }

        public string Wikipedia { get; set; }
        public string Details { get; set; }
    }
}