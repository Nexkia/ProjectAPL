using Newtonsoft.Json;


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
