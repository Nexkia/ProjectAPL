using Newtonsoft.Json;


namespace APL.Data
{
    internal class PcAssemblato
    {
        [JsonProperty("prezzoTot")]
        public float Prezzo { get; init; }
        [JsonProperty("componenti")]
        public Componente[] Componenti { get; init; }
    }
}
