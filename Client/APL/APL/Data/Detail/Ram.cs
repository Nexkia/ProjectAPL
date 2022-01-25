using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class Ram : Details
    {

        [JsonProperty("modello_ram")]
        public string Modello { get; init; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("frequenza")]
        public float Frequenza { get; init; }

        [JsonProperty("standard")]
        public string Standard { get; init; }

        public string[] getDetail()
        {
            if (Standard == null)
                return Array.Empty<string>();
            string[] detail = new string[2] {
                Convert.ToString(Frequenza),
                Standard,
            };
            return detail;
        }
    }
}
