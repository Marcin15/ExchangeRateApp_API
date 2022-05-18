using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CurrencySymbolEntity
    {
        [JsonProperty("symbols")]
        public Dictionary<string, string> Symbols { get; set; }
    }
}
