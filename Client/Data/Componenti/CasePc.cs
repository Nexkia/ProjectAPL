using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class CasePC : IFactory
    {
        [JsonProperty("modello_casepc")]
        public string Modello { get; private set; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; private set;}
        [JsonProperty("taglia")]
        public string Taglia { get; private set; }

        public bool getCompatibility()
        {
            throw new NotImplementedException();
        }

        public string[] getDetail()
        {
            string[] detail = new string[1] { this.Taglia };
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
