using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Memoria

    {
        [JsonProperty("memoria")]
        Componente componente;
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("tipo")]
        public string Tipo { get; private set; }

    }
}
