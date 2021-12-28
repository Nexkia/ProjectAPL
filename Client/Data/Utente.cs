using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Utente
    {

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Indirizzo")]
        public string Indirizzo { get; set; }


        [JsonProperty("NomeUtente")]
        public string Nome { get; set; }


        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
