using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data.Componenti
{
    class SchedaMadre: Detail
    {
        public string Modello { get; set; }
        public string Categoria { get; set; }
        public string[] CpuSocket { get; set; }
        public string[] Ram { get; set; }
        public bool SsdM2 { get; set; }

    }
}
