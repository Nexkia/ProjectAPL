using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class SchedaMadre : Details
    {

        [JsonProperty("modello_schedaMadre")]
        public string Modello { get; init; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("cpusocket")]
        public string CpuSocket { get; init; }
        [JsonProperty("ram")]
        public string Ram { get; init; }
        [JsonProperty("chipset")]
        public string Chipset { get; init; }

        public string[] getDetail()
        {
            string[] detail = new string[3] {
                CpuSocket,
                Ram,
                Chipset,
            };
            return detail;
        }
    }
}
