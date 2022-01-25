using System;


namespace APL.Data
{
    class Acquisto
    {
        public Acquisto(string PrezzoTot, DateTime Data, PcAssemblato[] PcAssemblati, string[] PcPreAssemblati,string[] PrezziPreAssemblati)
        {
            
            this.PrezzoTot = PrezzoTot;
            this.Data = Data;
            this.PcAssemblati = PcAssemblati;
            this.PcPreAssemblati = PcPreAssemblati;
            this.PrezziPreAssemblati = PrezziPreAssemblati;

        }

        public PcAssemblato[] PcAssemblati { get; private set; }
      
        public string[] PcPreAssemblati { get; private set; }
        
        public string PrezzoTot { get; private set; }

        public DateTime Data { get; private set; }

        public string[] PrezziPreAssemblati { get; private set; }


    }
}
