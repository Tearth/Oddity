using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oddity.API.Models.Capsules;
using Oddity.API.Models.Crew;
using Oddity.API.Models.Launchpads;
using Oddity.API.Models.Payloads;
using Oddity.API.Models.Rockets;
using Oddity.API.Models.Ships;

namespace Oddity.API.Models.Launches
{
    public class LaunchInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }

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

        public bool? Upcoming { get; set; }

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

        public Lazy<RocketInfo> Rocket { get; private set; }
        private string _rocketId;

        public bool? Success { get; set; }

        public List<string> Failures { get; set; }
        public string Details { get; set; }

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

        public List<Lazy<CrewInfo>> Crew { get; private set; }
        private List<string> _crewId;

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

        public List<Lazy<ShipInfo>> Ships { get; private set; }
        private List<string> _shipsId;

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

        public List<Lazy<CapsuleInfo>> Capsules { get; private set; }
        private List<string> _capsulesId;

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

        public List<Lazy<PayloadInfo>> Payloads { get; private set; }
        private List<string> _payloadsId;

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

        public Lazy<LaunchpadInfo> Launchpad { get; private set; }
        private string _launchpadId;

        [JsonProperty("auto_update")]
        public bool? AutoUpdate { get; set; }

        public List<LaunchCoreInfo> Cores { get; set; }
        public LaunchLinks Links { get; set; }
        public LaunchFairingsInfo Fairings { get; set; }
    }
}
