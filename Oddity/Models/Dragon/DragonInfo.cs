using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oddity.Models.Common;

namespace Oddity.Models.Dragon
{
    public class DragonInfo : ModelBase, IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? Active { get; set; }
        public string Wikipedia { get; set; }
        public string Description { get; set; }

        public SizeInfo Diameter { get; set; }
        public DragonTrunkInfo Trunk { get; set; }
        public List<DragonThrustersInfo> Thrusters { get; set; }

        [JsonProperty("crew_capacity")]
        public uint? CrewCapacity { get; set; }

        [JsonProperty("sidewall_angle_deg")]
        public uint? SidewallAngleDegrees { get; set; }

        [JsonProperty("orbit_duration_yr")]
        public uint? OrbitDurationYears { get; set; }

        [JsonProperty("dry_mass_kg")]
        public double? DryMassKilograms { get; set; }

        [JsonProperty("dry_mass_lb")]
        public double? DryMassPounds { get; set; }

        [JsonProperty("first_flight")]
        public DateTime? FirstFlight { get; set; }

        [JsonProperty("flickr_images")]
        public List<string> FlickrImages { get; set; }

        [JsonProperty("height_w_trunk")]
        public SizeInfo HeightWithTrunk { get; set; }

        [JsonProperty("heat_shield")]
        public DragonHeatshieldInfo HeatShield { get; set; }

        [JsonProperty("launch_payload_mass")]
        public MassInfo LaunchPayloadMass { get; set; }

        [JsonProperty("launch_payload_vol")]
        public VolumeInfo LaunchPayloadVolume { get; set; }

        [JsonProperty("return_payload_mass")]
        public MassInfo ReturnPayloadMass { get; set; }

        [JsonProperty("return_payload_vol")]
        public VolumeInfo ReturnPayloadVolume { get; set; }

        [JsonProperty("pressurized_capsule")]
        public DragonPressurizedCapsuleInfo PressurizedCapsule { get; set; }
    }
}
