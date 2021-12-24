using Client.Data.Componenti;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class PreAssemblato: PcAssemblato

    {
        

        [JsonProperty("nome")]
        public string Nome { get; set; }

        public void Inserimento()
        {
           for(int i = 0; i < 8; i++) { 
                Componenti[i].Categoria = "componentecategoria"+i; 
                Componenti[i].Marca = "componentimarca"+i; 
                Componenti[i].Modello = "componentimodello" + i;
                Componenti[i].Prezzo = i*1; 
                Componenti[i].Img = "";
                Componenti[i].Valutazione = 10 * i;
            }


        }

        public string Stampa()
        {
            return "" + Componenti[0].Categoria + " marca:" + Componenti[0].Marca + " modello:" + Componenti[0].Modello + "\n"
                        + Componenti[1].Categoria + " marca:" + Componenti[1].Marca + " modello:" + Componenti[1].Modello + "\n"
                        + Componenti[2].Categoria + " marca:" + Componenti[2].Marca + " modello:" + Componenti[2].Modello + "\n"
                        + Componenti[3].Categoria + " marca:" + Componenti[3].Marca + " modello:" + Componenti[3].Modello + "\n "
                        + Componenti[4].Categoria + " marca:" + Componenti[4].Marca + " modello:" + Componenti[4].Modello + "\n "
                        + Componenti[5].Categoria + " marca:" + Componenti[5].Marca + " modello:" + Componenti[5].Modello + "\n "
                        + Componenti[6].Categoria + " marca:" + Componenti[6].Marca + " modello:" + Componenti[6].Modello + "\n "
                        + Componenti[7].Categoria + " marca:" + Componenti[7].Marca + " modello:" + Componenti[7].Modello;
        }
    }
}
