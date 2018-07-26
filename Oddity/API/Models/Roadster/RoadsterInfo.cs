using Newtonsoft.Json;

namespace Oddity.API.Models.Roadster
{
    public class RoadsterInfo
    {
        public string Name { get; set; }

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
        public int EarthDistanceKm { get; set; }

        [JsonProperty("earth_distance_mi")]
        public int EarthDistanceMi { get; set; }

        [JsonProperty("mars_distance_km")]
        public int MarsDistanceKm { get; set; }

        [JsonProperty("mars_distance_mi")]
        public int MarsDistanceMi { get; set; }
    }
}