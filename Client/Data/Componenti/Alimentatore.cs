using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Alimentatore: Componente
    {
        [JsonProperty("alimentatore")]
        Componente componente;
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("watt")]
        public int Watt { get; private set; }
        
    }
}
