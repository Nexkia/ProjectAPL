using Client.Data.Componenti;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class preAssemblato: pcAssemblato

    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
