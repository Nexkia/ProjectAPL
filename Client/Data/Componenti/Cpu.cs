using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data.Componenti
{
    class Cpu: Detail
    {
        public string Modello { get; set; }
        public string Categoria { get; set; }
        public int Tdp { get; set; }
        public float Frequenza { get; set; }
        public string Socket { get; set; }
        public int Core { get; set; }
        public int Thread { get; set; }



      
    }

    
    
}
