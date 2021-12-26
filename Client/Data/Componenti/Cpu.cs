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
        [JsonProperty("componente")]
        public Componente Componente { get; set; }
        [JsonProperty("tdp")]
        public int Tdp { get; set; }
        [JsonProperty("frequenza")]
        public float Frequenza { get; set; }
        [JsonProperty("socket")]
        public string Socket { get; set; }
        [JsonProperty("core")]
        public int Core { get; set; }
        [JsonProperty("thread")]
        public int Thread { get; set; }



      
    }

    
    
}
