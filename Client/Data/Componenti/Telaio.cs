using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    class Telaio:Componente
    {
        [JsonProperty("taglia")]
        public string Taglia { get; set; }

    }
}
