using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data.Componenti
{
    class Alimentatore: Detail
    {
        public string Modello { get; set; }
        public string Categoria { get; set; }
        public int Watt { get; set; }
        
    }
}
