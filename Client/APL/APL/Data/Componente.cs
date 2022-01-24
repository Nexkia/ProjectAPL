using Newtonsoft.Json;


namespace APL.Data
{
    public class Componente
    {
        public Componente(string modello, string marca,float prezzo,int capienza, string categoria)
        {
            this.Modello = modello;
            this.Marca = marca;
            this.Prezzo = prezzo;
            this.Capienza = capienza;
            this.Categoria = categoria;
        }

        public Componente() { }
        [JsonProperty("prezzo")]
        public float Prezzo { get; private set; }
        [JsonProperty("marca")]
        public string? Marca { get; private set; }
        [JsonProperty("capienza")]
        public int Capienza { get; private set; }
       
        [JsonProperty("modello")]
        public string? Modello { get; private set; }
        [JsonProperty("categoria")]
        public string? Categoria { get; private set; }
    }
}
