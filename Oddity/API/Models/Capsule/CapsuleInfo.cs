using System.Collections.Generic;
using Newtonsoft.Json;
using Oddity.API.Models.Capsule.Heatshield;
using Oddity.API.Models.Capsule.Payload;
using Oddity.API.Models.Capsule.Thrusters;
using Oddity.API.Models.Common;

namespace Oddity.API.Models.Capsule
{
    public class CapsuleInfo
    {
        public CapsuleId? Id { get; set; }

        public string Name { get; set; }
        public bool? Active { get; set; }

        [JsonProperty("crew_capacity")]
        public uint? CrewCapacity { get; set; }

        [JsonProperty("sidewall_angle_deg")]
        public uint? SidewallAngleDegrees { get; set; }

        [JsonProperty("orbit_duration_yr")]
        public uint? OrbitDurationYears { get; set; }

        [JsonProperty("heat_shield")]
        public HeatshieldInfo Heatshield { get; set; }

        public List<ThrustersInfo> Thrusters { get; set; }

        [JsonProperty("launch_payload_mass")]
        public MassInfo LaunchPayloadMass { get; set; }

        [JsonProperty("launch_payload_vol")]
        public VolumeInfo LaunchPayloadVolume { get; set; }

        [JsonProperty("return_payload_mass")]
        public MassInfo ReturnPayloadMass { get; set; }

        [JsonProperty("return_payload_vol")]
        public VolumeInfo ReturnPayloadVolume { get; set; }

        [JsonProperty("pressurized_capsule")]
        public PressurizedCapsuleInfo PressurizedCapsule { get; set; }

        public TrunkInfo Trunk { get; set; }

        [JsonProperty("height_w_trunk")]
        public SizeInfo HeightWithTrunk { get; set; }

        public SizeInfo Diameter { get; set; }

        [JsonProperty("wikipedia")]
        public string Wikipedia { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
