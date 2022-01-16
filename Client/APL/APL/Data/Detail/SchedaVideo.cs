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
        public SchedaVideo(string modello, int valutazione, int tdp,int Vram)
        {
            this.Modello = modello;
            this.Valutazione = valutazione;
            this.Tdp = tdp;
            this.Vram = Vram;
        }

        public SchedaVideo() { }
        [JsonProperty("modello_schedaVideo")]
        public string? Modello { get; private set; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("tdp")]
        public int Tdp { get; private set; }

        [JsonProperty("vram")]
        public int Vram { get; private set; }


        public string[] getDetail()
        {
            string[] detail = new string[2] {
                Convert.ToString(Tdp),
                Convert.ToString(Vram),
            };
            return detail;
        }

        public string getModello()
        {
            if (Modello == null)   
                return String.Empty;
            return Modello;
        }

        public int getValutazione()
        {
            return Valutazione;
        }
    }
}
