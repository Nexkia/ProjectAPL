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
        [JsonProperty("componente")]
        public Componente Componente { get; set; }
        [JsonProperty("cpusocket")]
        public string[] CpuSocket { get; set; }
        

    }
}
