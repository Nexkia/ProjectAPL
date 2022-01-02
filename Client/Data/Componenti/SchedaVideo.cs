using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class SchedaVideo : IFactory
    {
        [JsonProperty("modello_schedaVideo")]
        public string Modello { get; private set; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("tdp")]
        public int Tdp { get; private set; }
        [JsonProperty("frequenza")]
        public float Frequenza { get; private set; }
        [JsonProperty("vram")]
        public int Vram { get; private set; }

        public void Stampa()
        {
            throw new NotImplementedException();
        }
    }
}
