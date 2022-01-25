using Newtonsoft.Json;


namespace APL.Data
{
    internal class Utente
    {
        [JsonProperty("Email")]
        public string Email {get; init; }

        [JsonProperty("Indirizzo")]
        public string Indirizzo {get; init; }

        [JsonProperty("NomeUtente")]
        public string Nome { get; init; }

        [JsonProperty("Password")]
        public string Password { get; init; }
    }
}
