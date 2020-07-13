using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oddity.Models.Capsules;
using Oddity.Models.Crew;
using Oddity.Models.Launchpads;
using Oddity.Models.Payloads;
using Oddity.Models.Rockets;
using Oddity.Models.Ships;

namespace Oddity.Models.Launches
{
    public class LaunchInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Upcoming { get; set; }
        public bool? Success { get; set; }
        public string Details { get; set; }

        public List<LaunchCoreInfo> Cores { get; set; }
        public LaunchLinks Links { get; set; }
        public LaunchFairingsInfo Fairings { get; set; }
        public List<string> Failures { get; set; }

        [JsonProperty("flight_number")]
        public uint? FlightNumber { get; set; }

        [JsonProperty("date_utc")]
        public DateTime? DateUtc { get; set; }

        [JsonProperty("date_unix")]
        public ulong? DateUnix { get; set; }

        [JsonProperty("date_local")]
        public DateTime? DateLocal { get; set; }

        [JsonProperty("date_precision")]
        public DatePrecision? DatePrecision { get; set; }

        [JsonProperty("static_fire_date_utc")]
        public DateTime? StaticFireDateUtc { get; set; }

        [JsonProperty("static_fire_date_unix")]
        public ulong? StaticFireDateUnix { get; set; }

        [JsonProperty("tbd")]
        public bool? ToBeDated { get; set; }

        [JsonProperty("net")]
        public bool? NotEarlierThan { get; set; }

        [JsonProperty("window")]
        public ulong? Window { get; set; }

        [JsonProperty("auto_update")]
        public bool? AutoUpdate { get; set; }

        [JsonProperty("rocket")]
        public string RocketId
        {
            get => _rocketId;
            set
            {
                _rocketId = value;
                Rocket = new Lazy<RocketInfo>(() => Context.RocketsEndpoint.Get(_rocketId).Execute());
            }
        }

        [JsonProperty("crew")]
        public List<string> CrewId
        {
            get => _crewId;
            set
            {
                _crewId = value;
                Crew = _crewId.Select(p => new Lazy<CrewInfo>(() => Context.CrewEndpoint.Get(p).Execute())).ToList();
            }
        }

        [JsonProperty("ships")]
        public List<string> ShipsId
        {
            get => _shipsId;
            set
            {
                _shipsId = value;
                Ships = _shipsId.Select(p => new Lazy<ShipInfo>(() => Context.ShipsEndpoint.Get(p).Execute())).ToList();
            }
        }

        [JsonProperty("capsules")]
        public List<string> CapsulesId
        {
            get => _capsulesId;
            set
            {
                _capsulesId = value;
                Capsules = _capsulesId.Select(p => new Lazy<CapsuleInfo>(() => Context.CapsulesEndpoint.Get(p).Execute())).ToList();
            }
        }

        [JsonProperty("payloads")]
        public List<string> PayloadsId
        {
            get => _payloadsId;
            set
            {
                _payloadsId = value;
                Payloads = _payloadsId.Select(p => new Lazy<PayloadInfo>(() => Context.PayloadsEndpoint.Get(p).Execute())).ToList();
            }
        }

        [JsonProperty("launchpad")]
        public string LaunchpadId
        {
            get => _launchpadId;
            set
            {
                _launchpadId = value;
                Launchpad = new Lazy<LaunchpadInfo>(() => Context.LaunchpadsEndpoint.Get(_launchpadId).Execute());
            }
        }

        public Lazy<RocketInfo> Rocket { get; private set; }
        public List<Lazy<CrewInfo>> Crew { get; private set; }
        public List<Lazy<ShipInfo>> Ships { get; private set; }
        public List<Lazy<CapsuleInfo>> Capsules { get; private set; }
        public List<Lazy<PayloadInfo>> Payloads { get; private set; }
        public Lazy<LaunchpadInfo> Launchpad { get; private set; }

        private string _rocketId;
        private List<string> _crewId;
        private List<string> _shipsId;
        private List<string> _capsulesId;
        private List<string> _payloadsId;
        private string _launchpadId;
    }
}
