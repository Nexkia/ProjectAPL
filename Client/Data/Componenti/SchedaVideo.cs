using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class SchedaVideo: Componente
    {
        [JsonProperty("tdp")]
        public int Tdp { get; set; }
        [JsonProperty("frequenza")]
        public float Frequenza { get; set; }
        [JsonProperty("vram")]
        public int Vram { get; set; }


    }
}
