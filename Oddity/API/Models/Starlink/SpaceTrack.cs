using System;
using Newtonsoft.Json;

namespace Oddity.API.Models.Starlink
{
    public class SpaceTrack
    {
        [JsonProperty("ccsds_omm_vers")]
        public string CcsdsOmmVers { get; set; }

        public string Comment { get; set; }

        [JsonProperty("creation_date")]
        public DateTime? CreationDate { get; set; }

        public string Originator { get; set; }

        [JsonProperty("object_name")]
        public string ObjectName { get; set; }

        [JsonProperty("object_id")]
        public string ObjectId { get; set; }

        [JsonProperty("center_name")]
        public string CenterName { get; set; }

        [JsonProperty("ref_frame")]
        public string RefFrame { get; set; }

        [JsonProperty("time_system")]
        public string TimeSystem { get; set; }

        [JsonProperty("mean_element_theory")]
        public string MeanElementTheory { get; set; }

        public DateTime? Epoch { get; set; }

        [JsonProperty("mean_motion")]
        public double? MeanMotion { get; set; }

        public double? Eccentricity { get; set; }
        public double? Inclination { get; set; }

        [JsonProperty("ra_of_asc_node")]
        public double? RaOfAscNode { get; set; }

        [JsonProperty("arg_of_pericenter")]
        public double? ArgOfPericenter { get; set; }

        [JsonProperty("mean_anomaly")]
        public double? MeanAnomaly { get; set; }

        [JsonProperty("ephemeris_type")]
        public int? EphemerisType { get; set; }

        [JsonProperty("classification_type")]
        public string ClassificationType { get; set; }

        [JsonProperty("norad_cat_id")]
        public int? NoradCatId { get; set; }

        [JsonProperty("element_set_no")]
        public int? NoradSetNo { get; set; }

        [JsonProperty("rev_at_epoch")]
        public int? RevAtEpoch { get; set; }

        public double? Bstar { get; set; }

        [JsonProperty("mean_motion_dot")]
        public double? MeanMotionDot { get; set; }

        [JsonProperty("mean_motion_ddot")]
        public double? MeanMotionDdot { get; set; }

        [JsonProperty("semimajor_axis")]
        public double? SemimajorAxis { get; set; }

        public double? Period { get; set; }
        public double? Apoapsis { get; set; }
        public double? Periapsis { get; set; }

        [JsonProperty("object_type")]
        public string ObjectType { get; set; }

        [JsonProperty("rcs_size")]
        public string RcsSize { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("launch_date")]
        public DateTime? LaunchDate { get; set; }

        public string Site { get; set; }

        [JsonProperty("decay_date")]
        public DateTime? DecayDate { get; set; }

        public int? Decayed { get; set; }
        public int? File { get; set; }

        [JsonProperty("gp_id")]
        public int? GpId { get; set; }

        [JsonProperty("tle_line0")]
        public string TleLine0 { get; set; }

        [JsonProperty("tle_line1")]
        public string TleLine1 { get; set; }

        [JsonProperty("tle_line2")]
        public string TleLine2 { get; set; }
    }
}
