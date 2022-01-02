using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Dissipatore : IFactory
    {
        [JsonProperty("modello_dissipatore")]
        public string Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("cpusocket")]
        public string[] CpuSocket { get; private set; }

        public void Stampa()
        {
            throw new NotImplementedException();
        }
    }
}
