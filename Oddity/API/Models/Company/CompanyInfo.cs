using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Oddity.API.Models.Company;

namespace Oddity.API.Models
{
    public class CompanyInfo
    {
        public string Name { get; set; }
        public string Founder { get; set; }
        public uint Founded { get; set; }
        public uint Employees { get; set; }
        public uint Vehicles { get; set; }

        [JsonProperty("launch_sites")]
        public uint LaunchSites { get; set; }

        [JsonProperty("test_sites")]
        public uint TestSites { get; set; }

        public string Ceo { get; set; }
        public string Cto { get; set; }
        public string Coo { get; set; }

        [JsonProperty("cto_propulsion")]
        public string CtoPropulsion { get; set; }

        public ulong Valuation { get; set; }
        public Headquarters Headquarters { get; set; }
        public string Summary { get; set; }
    }
}
