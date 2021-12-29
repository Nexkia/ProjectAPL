using Client.Data.Componenti;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data.Componenti
{
    class Pcassemblato
	{
		[JsonProperty("prezzoTot")]
		public float Prezzo { get; private set; }
		[JsonProperty("componenti")]
		public Componente[] Componenti { get; private set; }

	}
}
