﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    internal class Ram : Details
    {
        [JsonProperty("modello_ram")]
        public string? Modello { get; private set; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; private set; }
        [JsonProperty("frequenza")]
        public float Frequenza { get; private set; }

        [JsonProperty("standard")]
        public string? Standard { get; private set; }


        public string[] getDetail()
        {
            if (Standard == null)
                return Array.Empty<string>();
            string[] detail = new string[2] {
                Convert.ToString(Frequenza),
                Standard,
            };
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
            return Valutazione;
        }
    }
}