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
        public long  Number { get;  set; }
        [JsonProperty("month")]
        public int Month { get;  set; }
        [JsonProperty("year")]
        public int Year{ get;  set; }
        [JsonProperty("cvv")]
        public int CVV { get;  set; }


    }

 
}
