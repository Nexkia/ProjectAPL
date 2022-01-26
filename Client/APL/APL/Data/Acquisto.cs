using System;


namespace APL.Data
{
    class Acquisto
    {
        
        public PcAssemblato[] PcAssemblati { get; init; }
      
        public string[] PcPreAssemblati { get; init; }
        
        public string PrezzoTot { get; init; }

        public DateTime Data { get; init; }

        public string[] PrezziPreAssemblati { get; init; }
      
    }
}
