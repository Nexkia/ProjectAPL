using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class SchedaMadre : IFactory
    {
        [JsonProperty("modello_schedaMadre")]
        public string Modello { get; private set; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("cpusocket")]
        public string[] CpuSocket { get; private  set; }
        [JsonProperty("ram")]
        public string[] Ram { get; private set; }
        [JsonProperty("ssdm2")]
        public bool SsdM2 { get; private set; }

        public void Stampa()
        {
            throw new NotImplementedException();
        }
    }
}
