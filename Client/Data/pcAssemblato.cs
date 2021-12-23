using Client.Data.Componenti;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data.Componenti
{
    class pcAssemblato
    {
		[JsonProperty("prezzoTot")]
		public float Prezzo { get; set; }
		[JsonProperty("componente")]
		public Componente[] Componenti { get; set; }

	}
}
