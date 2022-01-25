using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data
{
    class Acquisto
    {
        
        public PcAssemblato[] PcAssemblati { get; init; }
      
        public string[] PcPreAssemblati { get; init; }
        
        public string PrezzoTot { get; init; }

        public DateTime Data { get; init; }
     
    }
}
