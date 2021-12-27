using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class CasePC
    {
        [JsonProperty("casepc")]
        Componente componente;
        [JsonProperty("valutazione")]
        public int Valutazione { get; set; }
        [JsonProperty("taglia")]
        public string Taglia { get; set; }

    }
}
