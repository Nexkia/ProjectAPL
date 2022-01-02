using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Memoria : IFactory

    {
        [JsonProperty("modello_memoria")]
        public string Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("tipo")]
        public string Tipo { get; private set; }

        public bool getCompatibility()
        {
            throw new NotImplementedException();
        }

        public string[] getDetail()
        {
            string[] detail = new string[1] { this.Tipo };
            return detail;
        }

        public string getModello()
        {
            return this.Modello;
        }

        public string[] getMoreDetail()
        {
            throw new NotImplementedException();
        }

        public int getValutazione()
        {
            return this.Valutazione;
        }
    }
}
