﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class SchedaMadre
    {
        [JsonProperty("schedamadre")]
        Componente componente;
        [JsonProperty("valutazione")]
        public int Valutazione { get; set; }
        [JsonProperty("cpusocket")]
        public string[] CpuSocket { get; set; }
        [JsonProperty("ram")]
        public string[] Ram { get; set; }
        [JsonProperty("ssdm2")]
        public bool SsdM2 { get; set; }

    }
}