using Client.Data.Componenti;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Preassemblato

    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("prezzoTot")]
        public float Prezzo { get; set; }
        [JsonProperty("componenti")]
        public Componente[] Componenti { get; set; }
    }
}
