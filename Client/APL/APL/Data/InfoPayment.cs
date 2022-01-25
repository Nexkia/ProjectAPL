using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data
{
    class InfoPayment
    {
        [JsonProperty("email")]
        public string Email { get; init; }

        [JsonProperty("indirizzoFatturazione")]
        public string IndirizzoFatturazione { get; init; }

        [JsonProperty("creditCard")]
        public CreditCard CreditCard { get; init; }
      
}
}
