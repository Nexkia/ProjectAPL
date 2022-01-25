using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class Dissipatore:Details
    {

        [JsonProperty("modello_dissipatore")]
        public string Modello { get; init; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("cpusocket")]
        public string[] CpuSocket { get; init; }

        public string[] getDetail()
        {
            return CpuSocket;
        }
    }
}
