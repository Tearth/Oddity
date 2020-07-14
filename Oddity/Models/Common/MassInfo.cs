using Newtonsoft.Json;

namespace Oddity.Models.Common
{
    public class MassInfo : ModelBase
    {
        [JsonProperty("kg")]
        public double? Kilograms { get; set; }

        [JsonProperty("lb")]
        public double? Pounds { get; set; }

        public override string ToString()
        {
            return $"{Kilograms} kg ({Pounds} lb)";
        }
    }
}
