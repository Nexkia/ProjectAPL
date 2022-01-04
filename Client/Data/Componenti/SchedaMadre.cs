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
        public string CpuSocket { get; private  set; }
        [JsonProperty("ram")]
        public string Ram { get; private set; }
        [JsonProperty("chipset")]
        public string Chipset { get; private set; }

 
        public string[] getDetail()
        {
            string[] detail = new string[3] {
                this.CpuSocket,
                this.Ram,
                this.Chipset,

            };
            return detail;
        }

        public string getModello()
        {
            return this.Modello;
        }


        public int getValutazione()
        {
            return this.Valutazione;
        }
    }
}
