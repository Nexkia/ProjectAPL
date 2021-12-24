using Client.Data.Componenti;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data.Componenti
{
    
    class PcAssemblato
    {
        private Componente[] componenti;

        
       public PcAssemblato()
        {
            this.componenti = new Componente[8];
            for (int i = 0; i < 8; i++)
            {
                componenti[i] = new Componente();
            }
        }

        [JsonProperty("prezzoTot")]
        public float Prezzo { get; set; }
        [JsonProperty("componenti")]
        public Componente[] Componenti { get => componenti; set => componenti = value; }





    }
}
