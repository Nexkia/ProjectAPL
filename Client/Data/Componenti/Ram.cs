using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Ram

    {
        [JsonProperty("componente")]
        public Componente Componente { get; set; }

        [JsonProperty("frequenza")]
        public float Frequenza { get; set; }
        [JsonProperty("capienza")]
        public int Capienza { get; set; }
        [JsonProperty("standard")]
        public string Standard { get; set; }
 
    }
}
