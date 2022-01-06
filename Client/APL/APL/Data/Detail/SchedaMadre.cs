using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    internal class SchedaMadre : Details
    {
        [JsonProperty("modello_schedaMadre")]
        public string? Modello { get; private set; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("cpusocket")]
        public string? CpuSocket { get; private set; }
        [JsonProperty("ram")]
        public string? Ram { get; private set; }
        [JsonProperty("chipset")]
        public string? Chipset { get; private set; }


        public string[] getDetail()
        {
            if (CpuSocket == null)
                return Array.Empty<string>();
            if (Ram == null)
                return Array.Empty<string>();
            if (Chipset == null)
                return Array.Empty<string>();
            string[] detail = new string[3] {
                CpuSocket,
                Ram,
                Chipset,

            };
            return detail;
        }

        public string getModello()
        {
            if (Modello == null)
                return string.Empty;
            return Modello;
        }


        public int getValutazione()
        {
            return Valutazione;
        }
    }
}
