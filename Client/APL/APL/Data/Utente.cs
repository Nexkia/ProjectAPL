using Newtonsoft.Json;


namespace APL.Data
{
    internal class Utente
    {
        [JsonProperty("Email")]
        public string? Email {get; set;}

        [JsonProperty("Indirizzo")]
        public string? Indirizzo {get; set;}

        [JsonProperty("NomeUtente")]
        public string? Nome { get; set; }

        [JsonProperty("Password")]
        public string? Password { get; set; }
    }
}
