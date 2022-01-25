using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class Alimentatore : Details
    {

        [JsonProperty("modello_alimentatore")]
        public string Modello { get; init; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("watt")]
        public int Watt { get; init; }
        public string[] getDetail()
        {
            string[] detail = new string[1] { 
                Convert.ToString(Watt) 
            };
            return detail;
        }
    }
}
