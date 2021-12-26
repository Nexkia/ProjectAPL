using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Telaio
    {
        [JsonProperty("componente")]
        public Componente Componente { get; set; }

        [JsonProperty("taglia")]
        public string Taglia { get; set; }

    }
}
