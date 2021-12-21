using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data.Componenti
{
    class SchedaVideo: Detail
    {

        public string Modello { get; set; }
        public string Categoria { get; set; }
        public int Tdp { get; set; }
        public float Frequenza { get; set; }
        public int Vram { get; set; }


    }
}
