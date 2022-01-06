using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    internal class CasePC : Details
    {
        [JsonProperty("modello_casepc")]
        public string? Modello { get; private set; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("taglia")]
        public string? Taglia { get; private set; }


        public string[] getDetail()
        {
            if (Taglia == null)
                return Array.Empty<string>();
            string[] detail = new string[1] { Taglia };
            return detail;
        }

        public string getModello()
        {
            if (Modello == null)
                return string.Empty;
            return Modello;
        }

        public int getValutazione()
        {
            return Valutazione;
        }
    }
}
