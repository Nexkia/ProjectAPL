﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public class Dissipatore:Details
    {
        public Dissipatore(string modello, int valutazione, string[] cpusocket)
        {
            this.Modello = modello;
            this.Valutazione = valutazione;
            this.CpuSocket = cpusocket;
        }

        public Dissipatore() { }
        [JsonProperty("modello_dissipatore")]
        public string? Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("cpusocket")]
        public string[]? CpuSocket { get; private set; }


        public string[] getDetail()
        {
            if (CpuSocket == null)
                return Array.Empty<string>();
            return CpuSocket;
        }

        public string getModello()
        {
            if (Modello == null)
                return string.Empty;
            return Modello;
        }
        public int getValutazione()
        {
            return Valutazione;
        }
    }
}
