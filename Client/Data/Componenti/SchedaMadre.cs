using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class SchedaMadre
    {
        [JsonProperty("schedamadre")]
        Componente componente;
        [JsonProperty("valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("cpusocket")]
        public string[] CpuSocket { get; private  set; }
        [JsonProperty("ram")]
        public string[] Ram { get; private set; }
        [JsonProperty("ssdm2")]
        public bool SsdM2 { get; private set; }

    }
}
