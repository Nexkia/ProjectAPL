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


        public Alimentatore(string modello, int valutazione,int watt)
        {
            this.Modello = modello;
            this.Valutazione = valutazione;
            this.Watt = watt;
        }

        public Alimentatore()
        {
           
        }

        [JsonProperty("modello_alimentatore")]
        public string? Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("watt")]
        public int Watt { get; private set; }
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
