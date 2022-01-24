using System;


namespace APL.Data
{
    class Acquisto
    {
        public Acquisto(string PrezzoTot, DateTime Data, PcAssemblato[] PcAssemblati, string[] PcPreAssemblati)
        {
            
            this.PrezzoTot = PrezzoTot;
            this.Data = Data;
            this.PcAssemblati = PcAssemblati;
            this.PcPreAssemblati = PcPreAssemblati;

        }

        
        public PcAssemblato[] PcAssemblati { get; private set; }
      
        public string[] PcPreAssemblati { get; private set; }
        
        public string PrezzoTot { get; private set; }

        public DateTime Data { get; private set; }
     
    }
}
