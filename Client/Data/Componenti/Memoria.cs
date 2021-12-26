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
        [JsonProperty("componente")]
        public Componente Componente { get; set; }
        [JsonProperty("dimensione")]
        public int Dimensione { get; set; }
        [JsonProperty("tipo")]
        public string Tipo { get; set; }

    }
}
