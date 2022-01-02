using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Alimentatore : IFactory
    {
        [JsonProperty("modello_alimentatore")]
        public string Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("watt")]
        public int Watt { get; private set; }

        public bool getCompatibility()
        {
            throw new NotImplementedException();
        }

        public string[] getDetail()
        {
            string[] detail = new string[1] { Convert.ToString(this.Watt) };
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
