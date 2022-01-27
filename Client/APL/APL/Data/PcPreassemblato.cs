using Newtonsoft.Json;


namespace APL.Data
{
    public class PcPreassemblato
    {
        [JsonProperty("nome")]
        public string Nome { get; init; }
        [JsonProperty("prezzoTot")]
        public float Prezzo { get; init; }
        [JsonProperty("componenti")]
        public Componente[] Componenti { get; init; }
    }
}
