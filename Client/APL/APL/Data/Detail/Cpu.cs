using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class Cpu : IDetails
    {
       

        [JsonProperty("modello_cpu")]
        public string Modello { get; init; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("frequenza")]
        public float Frequenza { get; init; }
        [JsonProperty("socket")]
        public string Socket { get; init; }
        [JsonProperty("core")]
        public int Core { get; init; }
        [JsonProperty("thread")]
        public int Thread { get; init; }

        public string[] GetDetail()
        {
            string[] detail = new string[] {
                Convert.ToString(Frequenza),
                Socket,
                Convert.ToString(Core),
                Convert.ToString(Thread),
            };
            return detail;
        }
    }
}
