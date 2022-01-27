using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class Ram : IDetails
    {

        [JsonProperty("modello_ram")]
        public string Modello { get; init; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("frequenza")]
        public float Frequenza { get; init; }

        [JsonProperty("standard")]
        public string Standard { get; init; }

        public string[] GetDetail()
        {
            string[] detail = new string[] {
                Convert.ToString(Frequenza),
                Standard,
            };
            return detail;
        }
    }
}
