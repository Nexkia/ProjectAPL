﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data
{
    public class Componente
    {
        [JsonProperty("prezzo")]
        public float Prezzo { get; private set; }
        [JsonProperty("marca")]
        public string? Marca { get; private set; }
        [JsonProperty("capienza")]
        public string? Capienza { get; private set; }
        [JsonProperty("img")]
        public string? Img { get; private set; }
        [JsonProperty("modello")]
        public string? Modello { get; private set; }
        [JsonProperty("categoria")]
        public string? Categoria { get; private set; }
    }
}