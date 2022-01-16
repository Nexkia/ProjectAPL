using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class Cpu : Details
    {
       
            public Cpu(string modello, int valutazione, float frequenza,string socket,int core,int thread)
            {
                this.Modello = modello;
                this.Valutazione = valutazione;
                this.Frequenza = frequenza;
                this.Socket = socket;
                this.Core = core;
                this.Thread = thread;
            }

            public Cpu() { }

            [JsonProperty("modello_cpu")]
        public string? Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }

        [JsonProperty("frequenza")]
        public float Frequenza { get; private set; }
        [JsonProperty("socket")]
        public string? Socket { get; private set; }
        [JsonProperty("core")]
        public int Core { get; private set; }
        [JsonProperty("thread")]
        public int Thread { get; private set; }



        public string[] getDetail()
        {
            if (Socket == null)
                return Array.Empty<string>();
            string[] detail = new string[4] {
                Convert.ToString(Frequenza),
                Socket,
                Convert.ToString(Core),
                Convert.ToString(Thread),
            };
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
