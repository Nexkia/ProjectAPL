using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Alimentatore
    {
        [JsonProperty("componente")]
        public Componente Componente { get; set; }

        [JsonProperty("watt")]
        public int Watt { get; set; }
        
    }
}
