using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data
{
    public class Componente
    {
 
        [JsonProperty("prezzo")]
        public float Prezzo { get; init; }
        [JsonProperty("marca")]
        public string Marca { get;init; }
        [JsonProperty("capienza")]
        public int Capienza { get; init; }
       
        [JsonProperty("modello")]
        public string Modello { get; init; }
        [JsonProperty("categoria")]
        public string Categoria { get; init; }
    }
}
