using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Client.Data
{
    class Componente
    {
        [JsonProperty("prezzo")]
        public float Prezzo { get;  set; }
        [JsonProperty("marca")]
        public string Marca { get;  set; }
        [JsonProperty("capienza")]
        public string Capienza { get; set; }
        [JsonProperty("img")]
        public string Img { get;  set; }
        [JsonProperty("modello")]
        public string Modello { get; set; }
        [JsonProperty("categoria")]
        public string Categoria { get; set; }

    }
}
