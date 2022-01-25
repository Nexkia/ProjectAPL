using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data
{
    class CreditCard
    {

        [JsonProperty("number")]
        public long  Number { get;  init; }
        [JsonProperty("month")]
        public int Month { get; init; }
        [JsonProperty("year")]
        public int Year{ get; init; }
        [JsonProperty("cvv")]
        public int CVV { get; init; }


    }

 
}
