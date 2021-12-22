using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Cpu: Componente
    {

        public int Tdp { get; set; }
        public float Frequenza { get; set; }
        public string Socket { get; set; }
        public int Core { get; set; }
        public int Thread { get; set; }



      
    }

    
    
}
