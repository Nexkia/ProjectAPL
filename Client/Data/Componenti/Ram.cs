using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Ram : IFactory

    {
        [JsonProperty("modello_ram")]
        public string Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("frequenza")]
        public float Frequenza { get; private set; }

        [JsonProperty("standard")]
        public string Standard { get; private set; }


        public string[] getDetail()
        {
            string[] detail = new string[2] {
                Convert.ToString(this.Frequenza),
                this.Standard,
            };
            return detail;
        }

        public string getModello()
        {
            return this.Modello;
        }

        public int getValutazione()
        {
            return this.Valutazione;
        }
    }
}
