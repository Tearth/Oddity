using System;
using Newtonsoft.Json;

namespace Oddity.Models.Starlink
{
    public class SpaceTrackInfo : ModelBase
    {
        [JsonProperty("CCSDS_OMM_VERS")]
        public string CcsdsOmmVers { get; set; }

        [JsonProperty("COMMENT")]
        public string Comment { get; set; }

        [JsonProperty("CREATION_DATE")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty("ORIGINATOR")]
        public string Originator { get; set; }

        [JsonProperty("OBJECT_NAME")]
        public string ObjectName { get; set; }

        [JsonProperty("OBJECT_ID")]
        public string ObjectId { get; set; }

        [JsonProperty("CENTER_NAME")]
        public string CenterName { get; set; }

        [JsonProperty("REF_FRAME")]
        public string RefFrame { get; set; }

        [JsonProperty("TIME_SYSTEM")]
        public string TimeSystem { get; set; }

        [JsonProperty("MEAN_ELEMENT_THEORY")]
        public string MeanElementTheory { get; set; }

        [JsonProperty("EPOCH")]
        public DateTime? Epoch { get; set; }

        [JsonProperty("MEAN_MOTION")]
        public double? MeanMotion { get; set; }

        [JsonProperty("ECCENTRICITY")]
        public double? Eccentricity { get; set; }

        [JsonProperty("INCLINATION")]
        public double? Inclination { get; set; }

        [JsonProperty("RA_OF_ASC_NODE")]
        public double? RaOfAscNode { get; set; }

        [JsonProperty("ARG_OF_PERICENTER")]
        public double? ArgOfPericenter { get; set; }

        [JsonProperty("MEAN_ANOMALY")]
        public double? MeanAnomaly { get; set; }

        [JsonProperty("EPHEMERIS_TYPE")]
        public uint? EphemerisType { get; set; }

        [JsonProperty("CLASSIFICATION_TYPE")]
        public string ClassificationType { get; set; }

        [JsonProperty("NORAD_CAT_ID")]
        public uint? NoradCatId { get; set; }

        [JsonProperty("ELEMENT_SET_NO")]
        public uint? NoradSetNo { get; set; }

        [JsonProperty("REV_AT_EPOCH")]
        public uint? RevAtEpoch { get; set; }

        [JsonProperty("BSTAR")]
        public double? Bstar { get; set; }

        [JsonProperty("MEAN_MOTION_DOT")]
        public double? MeanMotionDot { get; set; }

        [JsonProperty("MEAN_MOTION_DDOT")]
        public double? MeanMotionDdot { get; set; }

        [JsonProperty("SEMIMAJOR_AXIS")]
        public double? SemimajorAxis { get; set; }

        [JsonProperty("PERIOD")]
        public double? Period { get; set; }

        [JsonProperty("APOAPSIS")]
        public double? Apoapsis { get; set; }

        [JsonProperty("PERIAPSIS")]
        public double? Periapsis { get; set; }

        [JsonProperty("OBJECT_TYPE")]
        public string ObjectType { get; set; }

        [JsonProperty("RCS_SIZE")]
        public string RcsSize { get; set; }

        [JsonProperty("COUNTRY_CODE")]
        public string CountryCode { get; set; }

        [JsonProperty("LAUNCH_DATE")]
        public DateTime? LaunchDate { get; set; }

        [JsonProperty("SITE")]
        public string Site { get; set; }

        [JsonProperty("DECAY_DATE")]
        public DateTime? DecayDate { get; set; }

        [JsonProperty("DECAYED")]
        public uint? Decayed { get; set; }

        [JsonProperty("FILE")]
        public uint? File { get; set; }

        [JsonProperty("GP_ID")]
        public uint? GpId { get; set; }

        [JsonProperty("TLE_LINE0")]
        public string TleLine0 { get; set; }

        [JsonProperty("TLE_LINE1")]
        public string TleLine1 { get; set; }

        [JsonProperty("TLE_LINE2")]
        public string TleLine2 { get; set; }
    }
}
