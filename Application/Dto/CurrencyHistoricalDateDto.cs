using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CurrencyHistoricalDateDto
    {
        [JsonProperty("base")]
        public string BaseCurrency { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndTime { get; set; }

        [JsonProperty("rates")]
        public Dictionary<DateTime, Dictionary<string, float>> Rates { get; set; } = new Dictionary<DateTime, Dictionary<string, float>>();
    }
}
