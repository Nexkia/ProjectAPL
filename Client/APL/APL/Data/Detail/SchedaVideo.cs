using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class SchedaVideo :Details
    {

        [JsonProperty("modello_schedaVideo")]
        public string Modello { get; init; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("tdp")]
        public int Tdp { get; init; }

        [JsonProperty("vram")]
        public int Vram { get; init; }


        public string[] getDetail()
        {
            string[] detail = new string[2] {
                Convert.ToString(Tdp),
                Convert.ToString(Vram),
            };
            return detail;
        }
    }
}
