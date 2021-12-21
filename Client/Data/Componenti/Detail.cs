using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Data
{
    class Detail
    {

        public float Prezzo { get;  set; }
        public string Marca { get;  set; }
        public string Img { get;  set; }
        public int Valutazione { get; set; }
       
    }
}
