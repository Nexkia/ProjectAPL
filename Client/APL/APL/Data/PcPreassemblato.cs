using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data
{
    public class PcPreassemblato
    {
        public PcPreassemblato(string nome, float prezzo, Componente[] Componenti)
        {
            this.Nome = nome;
            this.Prezzo = prezzo;
            this.Componenti = Componenti;
        }

        
        [JsonProperty("nome")]
        public string? Nome { get; private set; }
        [JsonProperty("prezzoTot")]
        public float Prezzo { get; private set; }
        [JsonProperty("componenti")]
        public Componente[]? Componenti { get; private set; }
    }
}
