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

        public bool getCompatibility()
        {
            return this.SsdM2;
        }

        public string[] getDetail()
        {
            return this.CpuSocket;
        }

        public string getModello()
        {
            return this.Modello;
        }

        public string[] getMoreDetail()
        {
            return this.Ram;
        }

        public int getValutazione()
        {
            return this.Valutazione;
        }
    }
}
