using System;
using Newtonsoft.Json;

namespace Oddity.API.Models.History
{
    public class HistoryEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [JsonProperty("event_date_utc")]
        public DateTime? EventDate { get; set; }

        [JsonProperty("event_date_unix")]
        public ulong? EventDataUnix { get; set; }

        [JsonProperty("flight_number")]
        public uint? FlightNumber { get; set; }

        public string Details { get; set; }
        public EventLinks Links { get; set; }
    }
}
