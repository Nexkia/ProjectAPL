using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Cpu
    {
        [JsonProperty("modello_cpu")]
        public string Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("tdp")]
        public int Tdp { get; private set; }
        [JsonProperty("frequenza")]
        public float Frequenza { get; private set; }
        [JsonProperty("socket")]
        public string Socket { get; private set; }
        [JsonProperty("core")]
        public int Core { get; private set; }
        [JsonProperty("thread")]
        public int Thread { get; private set; }

    }

    
    
}
