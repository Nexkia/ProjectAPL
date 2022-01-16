﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class Memoria : Details
    {
        public Memoria(string modello, int valutazione, string tipo)
        {
            this.Modello = modello;
            this.Valutazione = valutazione;
            this.Tipo = tipo;
        }

        public Memoria() { }

        [JsonProperty("modello_memoria")]
        public string? Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("tipo")]
        public string? Tipo { get; private set; }

        public string[] getDetail()
        {
            if (Tipo == null)
                return Array.Empty<string>();
            string[] detail = new string[1] { Tipo };
            return detail;
        }

        public string getModello()
        {
            if (Modello == null)    
                return string.Empty;
            return Modello;
        }

        public int getValutazione()
        {
            return this.Valutazione;
        }
    }
}
