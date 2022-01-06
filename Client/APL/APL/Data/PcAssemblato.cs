using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data
{
    internal class PcAssemblato
    {
        [JsonProperty("prezzoTot")]
        public float Prezzo { get; private set; }
        [JsonProperty("componenti")]
        public Componente[]? Componenti { get; private set; }
    }
}
