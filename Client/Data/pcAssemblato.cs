using Client.Data.Componenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class pcAssemblato
    {
		public string Nome { get; set; }
		public Cpu Cpu { get; set; }
		public Ram Ram { get; set; }
		public SchedaMadre SchedaMadre { get; set; }
		public SchedaVideo SchedaVideo { get; set; }
		public Telaio Telaio { get; set; }
		public Memoria Memoria { get; set; }
		public Dissipatore Dissipatore { get; set; }
		public Alimentatore Alimentatore { get; set; }

		



	}
}
