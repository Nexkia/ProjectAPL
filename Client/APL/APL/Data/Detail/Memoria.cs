using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class Memoria : Details
    {

        [JsonProperty("modello_memoria")]
        public string Modello { get; init; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("tipo")]
        public string Tipo { get; init; }

        public string[] getDetail()
        {
            if (Tipo == null)
                return Array.Empty<string>();
            string[] detail = new string[1] { Tipo };
            return detail;
        }
    }
}
