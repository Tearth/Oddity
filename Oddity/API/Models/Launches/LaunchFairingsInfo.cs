using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oddity.API.Models.Ships;

namespace Oddity.API.Models.Launches
{
    public class LaunchFairingsInfo : ModelBase
    {
        public bool? Reused { get; set; }

        [JsonProperty("recovery_attempt")]
        public bool? RecoveryAttempt { get; set; }

        public bool? Recovered { get; set; }

        [JsonProperty("ships")]
        public List<string> ShipsId
        {
            get => _shipsId;
            set
            {
                _shipsId = value;

                Ships = new List<Lazy<ShipInfo>>();
                for (var i = 0; i < _shipsId.Count; i++)
                {
                    var index = i;
                    Ships.Add(new Lazy<ShipInfo>(() => Context.ShipsEndpoint.Get(_shipsId[index]).Execute()));
                }
            }
        }

        public List<Lazy<ShipInfo>> Ships { get; set; }
        private List<string> _shipsId;
    }
}
