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
        [JsonProperty("modello_casepc")]
        public string Modello { get; private set; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; private set;}
        [JsonProperty("taglia")]
        public string Taglia { get; private set; }

    }
}
