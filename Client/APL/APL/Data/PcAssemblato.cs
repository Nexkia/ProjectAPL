using Newtonsoft.Json;


namespace APL.Data
{
    internal class PcAssemblato
    {
        [JsonProperty("prezzoTot")]
        public float Prezzo { get; private set; }
        [JsonProperty("componenti")]
        public Componente[]? Componenti { get; private set; }
    }
}
