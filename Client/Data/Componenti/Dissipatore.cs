using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Dissipatore
    {
        [JsonProperty("dissipatore")]
        Componente componente;
        [JsonProperty("Valutazione")]
        public int Valutazione { get; set; }
        [JsonProperty("cpusocket")]
        public string[] CpuSocket { get; set; }
        

    }
}
