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
        public string? Modello { get;  set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; set; }
        [JsonProperty("watt")]
        public int Watt { get;  set; }
        public string[] getDetail()
        {
            string[] detail = new string[1] { Convert.ToString(Watt) };
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
